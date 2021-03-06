using NUnit.Framework;
using ReversePolishNotationConsoleApp;
using System;
using System.Collections.Generic;

namespace ReversePolishNotationConsoleAppTest
{
    [TestFixture]
    public class SplitterTests
    {
        private readonly ISplitter splitter = new Splitter();

        [TestCase()]
        public void SeparateOperandsAndOperatorsTest()
        {
            List<object> actual = splitter.SeparateOperandsAndOperators("2+3");
            List<object> expectedResult = new List<object>() { 2, '+', 3 };

            CollectionAssert.AreEqual(actual, expectedResult);
        }

        [TestCase("3--")]
        [TestCase("2++")]
        public void SeparateOperandsAndOperatorsTest_WrongInput(string input)
        {
            try
            {
                List<object> actual = splitter.SeparateOperandsAndOperators(input);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "�� ������ �������");
            }
        }


    }
}

