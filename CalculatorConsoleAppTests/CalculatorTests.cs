using CalculatorConsoleApp;
using NUnit.Framework;
using System;

namespace CalculatorConsoleAppTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase("1-5", "-4")]
        [TestCase("1+5", "6")]
        [TestCase("-2-2", "-4")]

        [TestCase("2*6", "12")]
        [TestCase("3*-4", "-12")]
        [TestCase("3*(-4)", "-12")]
        [TestCase("6/3", "2")]
        [TestCase("-8/2", "-4")]
        [TestCase("8/2*5", "20")]
        [TestCase("2,5*2", "5")]
        [TestCase("2,5*2,5", "6,25")]
        [TestCase("250*0,1", "25")]

        [TestCase("2+2*2", "6")]
        [TestCase("2-2*2", "-2")]


        [TestCase("2+(2*5)", "12")]
        [TestCase("(2+2)*2", "8")]
        [TestCase("(2*(2+2))*2", "16")]
        [TestCase("3,5*(2+2)", "14")]

        [TestCase("1+2-1*6/3", "1")]
        [TestCase("4+(3-1)*4/(1+1)", "8")]

        [TestCase("--7", "7")]

        public void CalcTest(string input, string expextedValue)
        {
            var actual = Calculator.Calc(input);

            Assert.AreEqual(expextedValue, actual);
        }
    }
}