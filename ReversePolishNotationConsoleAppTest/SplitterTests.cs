using NUnit.Framework;
using ReversePolishNotationConsoleApp;
using System.Collections.Generic;

namespace ReversePolishNotationConsoleAppTest
{
    [TestFixture]
    public class SplitterTests
    {
        [TestCase("2+3", 0, "2")]
        [TestCase("2+3", 2, "3")]
        [TestCase("2*345", 2, "345")]
        [TestCase("2+223+4", 2, "223")]

        public void GetNextOperandTest(string input, int index, string expextedValue)
        {
            var actual = Splitter.GetNextOperand(input, index);

            Assert.AreEqual(actual, expextedValue);
        }

        [TestCase()]
        public void TransformTest()
        {
            List<object> actual = Splitter.Transform("2+3");
            List<object> expectedResult = new List<object>() { 2, '+', 3 };

            CollectionAssert.AreEqual(actual, expectedResult);
        }

    }
}

