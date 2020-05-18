using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Calculator
{
    public static class ReaderWriter
    {
        public static void Reader(BlockingCollection<string> mathExpressionQueue)
        {
            
            while (true)
            {
                string newMathExpression = Console.ReadLine();
                mathExpressionQueue.Add(newMathExpression);
                if (newMathExpression == "STOP")
                {
                    break;
                }
            }
        }

        public static void Writer(BlockingCollection<Answer> calculationResultsQueue)
        {
            var calculationResult = calculationResultsQueue.Take();
            
            while (calculationResult.mathExpression != "STOP")
            {

                if (calculationResult.errors.Count == 0)
                {
                    Console.Write("Answer: ");
                    Console.WriteLine(calculationResult.answer);
                }
                else
                {
                    foreach (var error in calculationResult.errors)
                    {
                        printError(calculationResult.mathExpression, error);
                    }
                }

                calculationResult = calculationResultsQueue.Take();
            }
            
            calculationResultsQueue.Dispose();
        }
        
        private static void printError(string expression, KeyValuePair<string, int> error)
        {
            Console.WriteLine("Error: " + error.Key);
            Console.WriteLine(expression);
            for (int i = 1; i < error.Value; i++)
            {
                Console.Write('-');
            }

            Console.Write('^');
            for (int i = error.Value + 1; i <= expression.Length; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine();
        }
    }
}