using NUnit.Framework;
using ReversePolishNotationConsoleApp;
using System;

namespace ReversePolishNotationConsoleAppTest
{
    [TestFixture]
    class ValidatorTests
    {
        private readonly IValidator validator = new Validator();


        [TestCase("2+2")]
        [TestCase("2+2*(30/2)")]
        [TestCase("")]

        public void ValidateTest_RightInput(string input)
        {
            var actual = validator.Validate(input);

            Assert.IsTrue(actual);
        }

        [TestCase("2+2ahsh")]
        [TestCase("x+y=4")]
        public void ValidateTest_WrongInput_WithLetters(string input)
        {
            try
            {
                var transformedInput = validator.Validate(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Строка не должна содержать букв");
            }
        }

        [TestCase("2_2")]
        [TestCase("2=22")]
        public void ValidateTest_WrongInput_WithUnAllowedSymbols(string input)
        {
            try
            {
                var transformedInput = validator.Validate(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Строка содержит символы, которых быть не должно");
            }
        }

        [Test]
        public void ValidateTest_WrongInput_ExtraComma()
        {
            try
            {
                var transformedInput = validator.Validate("45,2,2");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Кажется, у вас были лишние запятые");
            }
        }

        [Test]
        public void ValidateTest_WrongInput_NotRightAmountOfBrackets()
        {
            try
            {
                var transformedInput = validator.Validate("23(()");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Открывающих и закрывающих скобок должно быть одинаковое количество");
            }
        }
    }
}

