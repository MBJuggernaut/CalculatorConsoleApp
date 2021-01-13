
using NUnit.Framework;
using ReversePolishNotationConsoleApp;
using System;

namespace ReversePolishNotationConsoleAppTest
{
    [TestFixture]
    public class CalculatorTests
    {
        private readonly ICalculator calculator = new Calculator();
        private readonly ISplitter splitter = new Splitter();
      
        [TestCase("2+3", 5)]
        [TestCase("2*3", 6)]
        [TestCase("2+2*2", 6)]
        [TestCase("2+4/2", 4)]
        [TestCase("5-2", 3)]
        [TestCase("2-5", -3)]
        [TestCase("2*(2+2)", 8)]
        [TestCase("2*(4/2)", 4)]
        [TestCase("1+2*(3+4/2-(1+2))*2+1", 10)]
        [TestCase("1-5", -4)]
        [TestCase("1+5", 6)]
        [TestCase("-2-2", -4)]
        [TestCase("3*-4", -12)]
        [TestCase("3*(-4)", -12)]
        [TestCase("6/3", 2)]
        [TestCase("-8/2", -4)]
        [TestCase("8/2*5", 20)]
        [TestCase("2,5*2,5", 6.25)]
        [TestCase("4+(3-1)*4/(1+1)", 8)]      

        public void CalcTest_RightInput(string input, double result)
        {            
            var transformedInput = splitter.SeparateOperandsAndOperators(input);
            var actual = calculator.Calc(transformedInput);

            Assert.AreEqual(actual, result);
        }

        [TestCase("4++")]
        [TestCase("4*3-2++4")]        
        [TestCase("3**6+7")]
        [TestCase("++")]

        public void CalcTest_WrongInput_NotEnoughOperands(string input)
        {
            try
            {
                var transformedInput = splitter.SeparateOperandsAndOperators(input);
                var actual = calculator.Calc(transformedInput);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "Мало операндов");
            }
            
        }

        [TestCase("4 4")]
        [TestCase("4*3-2+4 6 7")]
        [TestCase("3")]
        [TestCase("")]
        public void CalcTest_WrongInput_NotEnoughOperators(string input)
        {
            try
            {
                var transformedInput = splitter.SeparateOperandsAndOperators(input);
                var actual = calculator.Calc(transformedInput);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Недостаточно операций");
            }

        }
    }
}
