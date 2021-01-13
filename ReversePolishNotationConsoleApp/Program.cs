using System;

namespace ReversePolishNotationConsoleApp
{
    public class Program
    {           
        static void Main()
        {                        
            IValidator validator = new Validator();
            ICalculator calculator = new Calculator();
            ISplitter splitter = new Splitter();

            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    validator.Validate(input);
                    var separatedOperandsAndOperators = splitter.SeparateOperandsAndOperators(input);
                    Console.WriteLine(calculator.Calc(separatedOperandsAndOperators));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }            
        }


    }
}
