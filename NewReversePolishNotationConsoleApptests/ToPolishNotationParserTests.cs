using Moq;
using NewReversePolishNotationConsoleApp;
using NUnit.Framework;

namespace NewReversePolishNotationConsoleAppTests
{
    public class ToPolishNotationParserTests
    {
        IPolishNotationParser parser;
        public ToPolishNotationParserTests()
        {
            BasicOperationsLogicContainer logicContainer = new BasicOperationsLogicContainer();
            parser = new PolishNotationParser(logicContainer);
        }
        [TestCase("2+3", "2 3 + ")]
        [TestCase("2*3", "2 3 * ")]
        [TestCase("2+2*2", "2 2 2 * + ")]
        [TestCase("2*5/4", "2 5 * 4 / ")]
        [TestCase("2+3*(2+2)", "2 3 2 2 + * + ")]
        [TestCase("-(-3)+5", "-3 - 5 + ")]
        [TestCase("1+2*(3+4/2-(1+2))*2+1", "1 2 3 4 2 / 1 2 + - + * 2 * 1 + + ")]   


        public void ParseTests(string input, string expected)
        {
            var actual = parser.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}