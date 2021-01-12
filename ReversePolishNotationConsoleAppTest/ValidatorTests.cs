using NUnit.Framework;
using ReversePolishNotationConsoleApp;
using System;

namespace ReversePolishNotationConsoleAppTest
{
    [TestFixture]
    class ValidatorTests
    {
        private readonly IValidator validator = new Validator();


        [TestCase("2+2", true)]
        [TestCase("2+2*(30/2)", true)]
        [TestCase("", true)]

        public void IsValidTest_RightInput(string input, bool expextedValue)
        {
            var actual = validator.IsValid(input);

            Assert.AreEqual(expextedValue, actual);
        }

        [TestCase("2+2ahsh")]
        [TestCase("x+y=4")]
        public void IsValidTest_WrongInput_WithLetters(string input)
        {
            try
            {
                var transformedInput = validator.IsValid(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Строка не должна содержать букв");
            }
        }

        [TestCase("2_2")]
        [TestCase("2=22")]
        public void IsValidTest_WrongInput_WithUnAllowedSymbols(string input)
        {
            try
            {
                var transformedInput = validator.IsValid(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Строка содержит символы, которых быть не должно");
            }
        }

        [TestCase("45,2,2")]
        public void IsValidTest_WrongInput_ExtraComma(string input)
        {
            try
            {
                var transformedInput = validator.IsValid(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Кажется, у вас были лишние запятые");
            }
        }

        [TestCase("23(()")]
        public void IsValidTest_WrongInput_NotRightAmountOfBrackets(string input)
        {
            try
            {
                var transformedInput = validator.IsValid(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Открывающих и закрывающих скобок должно быть одинаковое количество");
            }
        }
    }
}

