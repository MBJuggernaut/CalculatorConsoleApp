using NewReversePolishNotationConsoleApp;
using NUnit.Framework;
using System;

namespace NewReversePolishNotationConsoleAppTests
{
    class ValidatorTests
    {
        IValidateUserInput validator;
        public ValidatorTests()
        {
            var logicContainer = new BasicOperationsLogicContainer();
            validator = new InputValidator(logicContainer);
        }

        [TestCase("2+2")]
        [TestCase("2+2*(30/2)")]
        [TestCase("")]
        public void ValidateTest_RightInput(string input)
        {
            bool actual = validator.IsValid(input);

            Assert.IsTrue(actual);
        }

        [TestCase("2+2ahsh")]
        [TestCase("x+y=4")]
        public void ValidateTest_WrongInput_WithLetters(string input)
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
        public void ValidateTest_WrongInput_WithUnAllowedSymbols(string input)
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
        [TestCase(",2,2")]
        [TestCase(",22")]
        public void ValidateTest_WrongInput_ExtraComma(string input)
        {
            var expected = "Слишком много запятых в одном из операндов";
            try
            {
                var transformedInput = validator.IsValid(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expected);
            }
        }

        [TestCase("23(()")]
        public void ValidateTest_WrongInput_NotRightAmountOfBrackets(string input)
        {
            var expected = "Открывающих и закрывающих скобок должно быть одинаковое количество";
            try
            {
                var transformedInput = validator.IsValid(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expected);
            }
        }

        [TestCase(")(")]
        [TestCase("(2))")]
        public void ValidateTest_WrongInput_NotRightOrderOfBrackets(string input)
        {
            var expected = "Закрывающая скобка не должна идти раньше открывающей";
            try
            {
                var transformedInput = validator.IsValid(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expected);
            }
        }
    }
}
