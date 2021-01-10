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
        [TestCase("2+3", 5)]
        [TestCase("2*3", 6)]
        [TestCase("2+2*2", 6)]
        [TestCase("2+4/2", 4)]
        [TestCase("5-2", 3)]
        [TestCase("2-5", -3)]
        [TestCase("2*(2+2)", 8)]
        [TestCase("2*(4/2)", 4)]
        [TestCase("1+2*(3+4/2-(1+2))*2+1", 10)]

        public void CalcTest(string input, double result)
        {
            var x = Splitter.Split(input);
            var y = Parser.Parse(x);
            var actual = Calculator.Calc(y);

            Assert.AreEqual(actual, result);
        }
    }
}
