using NewReversePolishNotationConsoleApp;
using NUnit.Framework;
using System;

namespace NewReversePolishNotationConsoleAppTests
{
    class ValidatorTests
    {
        [TestCase("2+2")]
        [TestCase("2+2*(30/2)")]
        [TestCase("")]

        public void ValidateTest_RightInput(string input)
        {
            bool actual = Validator.Validate(ref input);

            Assert.IsTrue(actual);
        }

        [TestCase("2+2ahsh")]
        [TestCase("x+y=4")]
        public void ValidateTest_WrongInput_WithLetters(string input)
        {
            try
            {
                var transformedInput = Validator.Validate(ref input);
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
                var transformedInput = Validator.Validate(ref input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Строка содержит символы, которых быть не должно");
            }
        }

        [Test]
        public void ValidateTest_WrongInput_ExtraComma()
        {
            var input = "45,2,2";
            try
            {
                var transformedInput = Validator.Validate(ref input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Слишком много запятых в одном из операндов");
            }
        }

        [Test]
        public void ValidateTest_WrongInput_NotRightAmountOfBrackets()
        {
            var input = "23(()";
            try
            {
                var transformedInput = Validator.Validate(ref input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Открывающих и закрывающих скобок должно быть одинаковое количество");
            }
        }
    }
}
