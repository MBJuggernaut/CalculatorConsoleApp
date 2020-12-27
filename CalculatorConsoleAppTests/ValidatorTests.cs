using CalculatorConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsoleAppTests
{
    [TestFixture]
    class ValidatorTests
    {
        [TestCase("2+2", true)]
        [TestCase("2+2*(30/2)", true)]
        [TestCase("2+2ahsh", false)]
        [TestCase("2/*3", false)]
        [TestCase("", true)]
        [TestCase("2_2", false)]
        [TestCase("23(()", false)]
        [TestCase("2=22", false)]
        [TestCase("45,2,2", false)]
        [TestCase("45,2,2", false)]

        public void IsValidTest(string input, bool expextedValue)
        {
            Action<string> method = (message) => { Console.WriteLine(message); };
            Validator validator = new Validator(method);

            var actual = validator.IsValid(input);

            Assert.AreEqual(expextedValue, actual);
        }
    }
}
