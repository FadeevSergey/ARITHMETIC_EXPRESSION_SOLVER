using System.Collections.Concurrent;
using System.Threading;

namespace Calculator
{
    static class CalculatorMain
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> mathExpressionQueue = new BlockingCollection<string>();
            BlockingCollection<Answer> calculationResultsQueue = new BlockingCollection<Answer>();
            
            Thread threadOfWriting = new Thread(() =>
            {
                ReaderWriter.Writer(calculationResultsQueue);
            });
            
            Thread threadOfCalculation = new Thread(() =>
            {
                ExpressionParser.Start(mathExpressionQueue, calculationResultsQueue);
            });
            
            threadOfWriting.Start();
            threadOfCalculation.Start();
            
            ReaderWriter.Reader(mathExpressionQueue);
        }
    }
}