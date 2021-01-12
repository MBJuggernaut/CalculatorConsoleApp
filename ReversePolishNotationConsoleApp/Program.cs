using System;
using System.Collections.Generic;

namespace ReversePolishNotationConsoleApp
{
    public class Program
    {           
        static void Main()
        {                        
            IValidate validator = new Validator();
            ICalculate calculator = new Calculator();

            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    validator.IsValid(input);
                    var transformedInput = Splitter.Transform(input);
                    calculator.Calc(transformedInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }            
        }


    }
}
