using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTest
    {
        [Test]
        public void TestOneNumber()
        {
            string mathExpression = "                          1";
            double expectedAnswer = 1;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestOneNegativeNumber()
        {
            string mathExpression = "-1";
            double expectedAnswer = -1;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestOneNumberWithPoint()
        {
            string mathExpression = "1.111";
            double expectedAnswer = 1.111;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestOneNegativeNumberWithPoint()
        {
            string mathExpression = "-1.111";
            double expectedAnswer = -1.111;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestOnePositiveNumberWithPoint()
        {
            string mathExpression = "                    +1.11";
            double expectedAnswer = 1.11;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithoutMulDiv1()
        {
            string mathExpression = "     1+1 +           (     -1 + (-1))";
            double expectedAnswer = 0;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithoutMulDiv2()
        {
            string mathExpression = "1 * 2 - 1.1111111 - 111111.111 + (1 + 1) * (1 - 2 + 0.0)";
            double expectedAnswer = -111112.2;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }

        [Test]
        public void TestExpressionWithoutMulDiv3()
        {
            string mathExpression = "(((((((1) + 1) + 1) + 1) + 1) + 1) + 1) - 7";
            double expectedAnswer = 0;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithWhitespaces()
        {
            string mathExpression = "     \n\n\n\n              1 +1 +       \n\n (1- 1) * (1/ (1 - 2))";
            double expectedAnswer = 2;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithMulDiv1()
        {
            string mathExpression = "(20/5/2/2/2/2)*2*(1+1)-(1-2)/(1-2)";
            double expectedAnswer = 0;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithMulDiv2()
        {
            string mathExpression = "121 + 49/7 - 256/2 + 99/3.3 - 11/11 +0.999999999";
            double expectedAnswer = 30;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithInsignificantZeros1()
        {
            string mathExpression = "(3-2)*(3/1+2/1)/(6/2+4/2) + 001 - 080 + (0-3)/(6-3)";
            double expectedAnswer = -79;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithInsignificantZeros2()
        {
            string mathExpression = "0.001*1000/0000000001  + 0000/0.1";
            double expectedAnswer = 1;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        //
        [Test]
        public void TestMulDivSumSub()
        {
            string mathExpression = "(56-56*1/2 -56/2)-(78 + 12/3 -82*0.5 -1/4*164)/1";
            double expectedAnswer = 0;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestDecimalNumberDivDecimalNumber()
        {
            string mathExpression = "1.11111111/1.1111";
            double expectedAnswer = 1.00001;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestBigExpression1()
        {
            string mathExpression = "((((3 - ((( 4 ) )) / 6 ) / 7 * (0.5 + 0.05 * 50 + 0 + 0 + 0 + 0 + 0 + 0.001 - " +
                                    "0.0001 * ((0.5 + 1.5) * 1 / 0.0002) - 0.001))))";
            double expectedAnswer = 0.6666667;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestBigExpression2()
        {
            string mathExpression = "((((((((((((((((((((((((((((((1 + 2) * 5) / 3) * 188) - 12) - 12) - 13) - " +
                                    "7777))))))))) - 4.5 * (3.4 / (2 + 2.222)))) - 1.234))))) + 1.2340001)))))))";
            double expectedAnswer = -6877.624;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionInBrackets1()
        {
            string mathExpression = "(5.62 + 7.38)";
            double expectedAnswer = 13;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionInBrackets2()
        {
            string mathExpression = "((20.63 + (-15.01)) + 7.38)";
            double expectedAnswer = 13;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionInBrackets3()
        {
            string mathExpression = "(((((((((((((-0)))))))))))))";
            double expectedAnswer = 0;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionInBrackets4()
        {
            string mathExpression = "((20.63 + (-(67.5 + (-52.49)))) + 7.38)";
            double expectedAnswer = 13;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionInBrackets5()
        {
            string mathExpression = "((20.63 + (-((15.16 + 52.34) + (-52.49)))) + 7.38)";
            double expectedAnswer = 13;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestExpressionWithoutWhitespaces()
        {
            string mathExpression = "((6.63+(56.62+16.8))+(-((60.53+3.61)+14.91)))";
            double expectedAnswer = 1;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestMinuses1()
        {
            string mathExpression = "-(-1.111) - (-1)";
            double expectedAnswer = 2.111;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestMinuses2()
        {
            string mathExpression = "-(-(-(-(-(-(-(-(-1))))))))";
            double expectedAnswer = -1;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestBigExpression4()
        {
            string mathExpression = "12/(((3-4)-200*0.01)+3-(4-5*(4*(66-0066)-5*(5-(5-(5-5))))))";
            double expectedAnswer = -3;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestBigExpression5()
        {
            string mathExpression = "1/1*111111111111111111111111111111111*000000000000000001*0.0";
            double expectedAnswer = 0;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestBigExpression6()
        {
            string mathExpression = "(1.1+(3.3*(5.5-(7.7/(9.9+(11.11-(13.13*(15.15/(17.17)-16.16)+14.14)/" +
                                    "12.12)*10.1)*8.8)+6.6)/4.4)-2.2)";
            double expectedAnswer = 7.791859;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestPerformance()
        {
            string mathExpression = "1";
            for (int i = 0; i < 100000; i++)
            {
                mathExpression += " + 1";
            }
            double expectedAnswer = 100001;
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count == 0 && Math.Abs(result.answer - expectedAnswer) < 0.1;
            Assert.IsTrue(testPass, "Expected 0 errors, but was found " + result.errors.Count + 
                                    "\n Answer " + expectedAnswer + ", but was found" + result.answer);
        }
        
        [Test]
        public void TestError1()
        {
            string mathExpression = "((( 1 + 1) + 1)";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError2()
        {
            string mathExpression = "30*0/(0*0/1)+0/(1-99-88-77-66)";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError3()
        {
            string mathExpression = "2*(1-(2-3-5*(6-5)))*(1-(2-3-5*(6-5)))*()";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError4()
        {
            string mathExpression = "()()()()()()()()() 1-1 ()()()()()()()(1-2)()() + 000001";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError5()
        {
            string mathExpression = "(6-5)*(6+5) - (6+5)/(6-5) +06-5+605 -0.605 -0.6+5 -1/0";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError6()
        {
            string mathExpression = "((((((((((((((((((((((((((((((1 + 2) * 5) / 3) * 188) - 12) - 12) - 13) - 7777))))))))) - 4.5 * (3.4 / (2 + 2.222)))) - 1.234))))) + 1.2340001))))))";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError7()
        {
            string mathExpression = "((((((((((((((((((((((((((((((1 + 2) * 5) / 3) * 188) - 12) - 12) - 13) - 7777))))))))) - 4.5 * (3.4 / (2 + 2.222 - 2.111 * 2)))) - 1.234))))) + 1.2340001)))))))";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError8()
        {
            string mathExpression = "11111.11111111.11111";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError9()
        {
            string mathExpression = "))))(((";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
        
        [Test]
        public void TestError10()
        {
            string mathExpression = "(((";
            var result = ExpressionParser.calculate(mathExpression);
            bool testPass = result.errors.Count > 0;
            Assert.IsTrue(testPass, "Expression content error");
        }
    }
}