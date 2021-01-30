using NewReversePolishNotationConsoleApp;
using NUnit.Framework;

namespace NewReversePolishNotationConsoleApptests
{
    public class ToPolishNotationParserTests
    {
        [TestCase("2+3", "2 3 + ")]
        [TestCase("2*3", "2 3 * ")]
        [TestCase("2+2*2", "2 2 2 * + ")]
        [TestCase("2*5/4", "2 5 * 4 / ")]
        [TestCase("2+3*(2+2)", "2 3 2 2 + * + ")]
        [TestCase("-(-3)+5", "3 - - 5 + ")]
        
        public void ParseTests(string input, string expected)
        {
            var actual = ToPolishNotationParser.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}