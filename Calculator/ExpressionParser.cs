using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Calculator
{
    public static class ExpressionParser
    {
        private enum Token
        {
            Number,
            Start,
            End,
            Plus = '+',
            Minus = '-',
            Mul = '*',
            Div = '/',
            LeftBracket = '(',
            RightBracket = ')'
        }

        private static int _currentPosition;
        private static string _expression;

        private static Token _currentToken;
        private static double _lastReadNumber;
        private static List<KeyValuePair<string, int>> _errors;
        private static int _bracketBalance;

        public static void Start(BlockingCollection<string> mathExpressions, 
                                 BlockingCollection<Answer> calculationResultsQueue)
        {
            CleanPrivateFields();
            string newMathExpression = mathExpressions.Take();
            
            while (newMathExpression != "STOP")
            {
                var calculationResult = calculate(newMathExpression);
                
                calculationResultsQueue.Add(calculationResult);
                
                newMathExpression = mathExpressions.Take();
            }

            if (newMathExpression == "STOP")
            {
                calculationResultsQueue.Add(new Answer(newMathExpression, 0, null));
                mathExpressions.Dispose();
            }
        }

        private static Token GetNextToken()
        {
            while (_currentPosition < _expression.Length && (Char.IsWhiteSpace(_expression[_currentPosition])))
            {
                _currentPosition++;
            }
            
            if (_currentPosition == _expression.Length)
            {
                return _currentToken = Token.End;
            }

            switch (_expression[_currentPosition])
            {
                case '-':
                case '+':
                case '*':
                case '/':
                    return _currentToken = (Token) _expression[_currentPosition++];
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    _lastReadNumber = GetNumberFromExpression(_currentPosition);
                    return _currentToken = Token.Number;
                case '(':
                    _currentPosition++;
                    _bracketBalance++;
                    return _currentToken = Token.LeftBracket;
                case ')':
                    _currentPosition++;
                    _bracketBalance--;
                    if (_bracketBalance < 0)
                    {
                        AddError("Incorrect bracket sequence", _currentPosition);
                    }

                    if (_currentToken == Token.LeftBracket)
                    {
                        AddError("Brackets without expression", _currentPosition);
                    }
                    return _currentToken = Token.RightBracket;
                default:
                    AddError("Unknown character", _currentPosition);
                    _currentPosition++;
                    return Token.End;
            }
        }

        private static double PrimaryExpression(bool get)
        {
            if (get)
            {
                GetNextToken();
            }

            switch (_currentToken)
            {
                case Token.Number:
                    double number = _lastReadNumber;
                    GetNextToken();
                    return number;
                case Token.LeftBracket:
                    double result = Expression(true);
                    GetNextToken();
                    return result;
                default:
                    return 0;
            }
        }

        private static double Terminal(bool get)
        {
            double left = PrimaryExpression(get);

            while (true)
            {
                switch (_currentToken)
                {
                    case Token.Mul:
                        left *= PrimaryExpression(true);
                        break;
                    case Token.Div:
                        double divider = PrimaryExpression(true);
                        if (Math.Abs(divider) < 0.00001)
                        {
                            AddError("Divide by zero", _currentPosition - 2);
                        }
                        else
                        {
                            left /= divider;
                        }

                        break;
                    default:
                        return left;
                }
            }
        }

        private static double Expression(bool get)
        {
            double left = Terminal(get);

            while (true)
            {
                switch (_currentToken)
                {
                    case Token.Plus:
                        left += Terminal(true);
                        break;
                    case Token.Minus:
                        left -= Terminal(true);
                        break;
                    default:
                        if (_currentToken == Token.Number)
                        {
                            AddError("Missing operator", _currentPosition);
                            Terminal(true);
                        }

                        if (_currentToken == Token.End)
                        {
                            return left;   
                        }

                        return left;
                }
            }
        }

        public static Answer calculate(string expression)
        {
            CleanPrivateFields();

            _expression = expression;
            GetNextToken();
            if (_currentToken == Token.End)
            {
                AddError("Empty input expression", 0);
            }
            double answer = Expression(false);
            if (_bracketBalance > 0)
            {
                AddError("Incorrect bracket sequence", _currentPosition);
            }
            return new Answer(_expression, answer, _errors);
        }

        private static void CleanPrivateFields()
        {
            _expression = "";
            _currentToken = Token.Start;
            _errors = new List<KeyValuePair<string, int>>();

            _currentPosition = 0;
            _bracketBalance = 0;
        }

        private static void AddError(string errorInformation, int position)
        {
            _errors.Add(new KeyValuePair<string, int>(errorInformation, position));
        }

        private static double GetNumberFromExpression(int startOfNumber)
        {
            double result;
            int endOfNumber = startOfNumber + 1;
            bool alreadyMetThePoint = false;
            bool expressionIsValid = true;
            while (endOfNumber < _expression.Length &&
                   (Char.IsDigit(_expression[endOfNumber]) || _expression[endOfNumber] == '.'))
            {
                if (_expression[endOfNumber] == '.')
                {
                    if (alreadyMetThePoint)
                    {
                        string message = "Invalid place for character '" + _expression[endOfNumber] + "'";
                        AddError(message, endOfNumber);
                        expressionIsValid = false;
                    }
                    else
                    {
                        alreadyMetThePoint = true;
                    }
                }

                endOfNumber++;
            }

            if (expressionIsValid)
            {
                result = double.Parse(_expression.Substring(startOfNumber, endOfNumber - startOfNumber));
            }
            else
            {
                result = Double.NaN;
            }

            _currentPosition = endOfNumber;
            return result;
        }
    }
}