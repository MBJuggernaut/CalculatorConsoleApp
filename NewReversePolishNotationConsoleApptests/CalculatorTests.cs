﻿using NewReversePolishNotationConsoleApp;
using NUnit.Framework;
using System;

namespace NewReversePolishNotationConsoleAppTests
{
    public class CalculatorTests
    {
        readonly ICalculate calculator;
        public CalculatorTests()
        {
            var provider = MyContainer.Initialize();
            calculator = new Calculator(provider);
        }

        [TestCase("2+3", 5)]
        [TestCase("2*3", 6)]
        [TestCase("2+2*2", 6)]
        [TestCase("2+4/2", 4)]
        [TestCase("5-2", 3)]
        [TestCase("2-5", -3)]
        [TestCase("2*(2+2)", 8)]
        [TestCase("2*(4/2)", 4)]
        [TestCase("1+2*(3+4/2-(1+2))*2+1", 10)]
        [TestCase("1-5", -4)]
        [TestCase("1+5", 6)]
        [TestCase("-2-2", -4)]
        [TestCase("3*(-4)", -12)]
        [TestCase("6/3", 2)]
        [TestCase("-8/2", -4)]
        [TestCase("8/2*5", 20)]
        [TestCase("2,5*2,5", 6.25)]
        [TestCase("4+(3-1)*4/(1+1)", 8)]
        [TestCase("-(-3)+5", 8)]
        [TestCase("(-3+5)", 2)]
        public void CalculateTests_EverythingAllright(string input, double expected)
        {
            var actual = calculator.Calculate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("4+(3-1)*4/(1+1)v", "Строка не должна содержать букв")]
        public void CalculateTests_CrachesAtValidator(string input, string expected)
        {
            try
            {
                var actual = calculator.Calculate(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expected);
            }
        }

        [TestCase("3 3", "Не удалось подсчитать выражение")]
        [TestCase("", "Не удалось подсчитать выражение")]
        public void CalculateTests_CrachesAtCalculator(string input, string expected)
        {
            try
            {
                var actual = calculator.Calculate(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expected);
            }
        }

    }
}
