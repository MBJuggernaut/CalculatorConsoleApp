using NewReversePolishNotationConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewReversePolishNotationConsoleAppTests
{
    public class CalculatorTests
    {
        [TestCase("2 3 + ", 5)]
        [TestCase("2 3 * " , 6)]
        [TestCase("2 2 2 * + ", 6)]
        [TestCase("2 5 * 4 / ", 2.5)]
        [TestCase("2 3 2 2 + * + ", 14)]
        [TestCase("6 2 /", 3)]
        public void CalculateTests(string input, double expected)
        {
            var actual = Calculator.Calculate(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
