using System.Collections.Generic;

namespace Calculator
{
    public class Answer
    {
        public readonly string mathExpression;
        public readonly double answer;
        public readonly List<KeyValuePair<string, int>> errors;

        public Answer(string mathExpression, double answer, List<KeyValuePair<string, int>> errors)
        {
            this.mathExpression = mathExpression;
            this.answer = answer;
            this.errors = errors;
        }
    }
}