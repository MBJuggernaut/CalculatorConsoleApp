using NUnit.Framework;
using ReversePolishNotationConsoleApp;
using System;

namespace ReversePolishNotationConsoleAppTest
{
    [TestFixture]
    class ValidatorTests
    {
        
        Validator validator = new Validator();


        [TestCase("2+2", true)]
        [TestCase("2+2*(30/2)", true)]
        [TestCase("2+2ahsh", false)]        
        [TestCase("", true)]
        [TestCase("2_2", false)]
        [TestCase("23(()", false)]
        [TestCase("2=22", false)]
        [TestCase("45,2,2", false)]
        [TestCase("45,2,2", false)]

        public void IsValidTest(string input, bool expextedValue)
        {
            var actual = validator.IsValid(input);

            Assert.AreEqual(expextedValue, actual);
        }
    }
}

