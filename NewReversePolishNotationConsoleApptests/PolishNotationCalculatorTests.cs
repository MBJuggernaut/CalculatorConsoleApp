using NewReversePolishNotationConsoleApp;
using NUnit.Framework;

namespace NewReversePolishNotationConsoleAppTests
{
    public class PolishNotationCalculatorTests
    {
        IPolishNotationCalculate calculator;
        public PolishNotationCalculatorTests()
        {
            BasicOperationsLogicContainer logicContainer = new BasicOperationsLogicContainer();
            calculator = new PolishNotationCalculator(logicContainer);
        }
        [TestCase("2 3 + ", 5)]
        [TestCase("2 3 * " , 6)]
        [TestCase("2 2 2 * + ", 6)]
        [TestCase("2 5 * 4 / ", 2.5)]
        [TestCase("2 3 2 2 + * + ", 14)]
        [TestCase("6 2 /", 3)]
        [TestCase("3 - - 5 + ", 8)]       
        [TestCase("1 2 3 4 2 / 1 2 + - + * 2 * 1 + + ", 10)]         
        public void CalculateTests(string input, double expected)
        {
            var actual = calculator.Calculate(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
