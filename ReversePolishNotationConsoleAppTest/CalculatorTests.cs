using NUnit.Framework;
using ReversePolishNotationConsoleApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleAppTest
{
    [TestFixture]
    class CalculatorTests
    {
        private readonly Calculator calculator = new Calculator();
        private readonly IValidate validator = new Validator();

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
        [TestCase("3*-4", -12)]
        [TestCase("3*(-4)", -12)]
        [TestCase("6/3", 2)]
        [TestCase("-8/2", -4)]
        [TestCase("8/2*5", 20)]
        [TestCase("(3 – 6) * (2 + 1)", -9)]
        [TestCase("2,5*2,5", 6.25)]
        [TestCase("4+(3-1)*4/(1+1)", 8)]
        [TestCase("11%10", 1)]


        public void CalcTest(string input, double result)
        {
            validator.IsValid(input);
            var transformedInput = Splitter.Transform(input);
            var actual = calculator.Calc(transformedInput);

            Assert.AreEqual(actual, result);
        }
    }
}
