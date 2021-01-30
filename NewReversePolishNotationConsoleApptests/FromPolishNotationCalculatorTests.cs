using Moq;
using NewReversePolishNotationConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewReversePolishNotationConsoleAppTests
{

    public class FromPolishNotationCalculatorTests
    {
        IFromPolishNotationCalculate calculator;
        public FromPolishNotationCalculatorTests()
        {
            BasicOperationsLogicContainer logicContainer = new BasicOperationsLogicContainer();
            calculator = new FromPolishNotationCalculator(logicContainer);
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
