using System;
using System.Collections.Generic;

namespace ReversePolishNotationConsoleApp
{
    public class Program
    {           
        static void Main(string[] args)
        {
            Action<string> method = (message) => { Console.WriteLine(message); };
            List<char> operators = new List<char>() { '(', ')', '*', '/', '+', '-', ',' };
            IValidator validator = new Validator(operators, method);
            ICalculator calculator = new Calculator();
            while (true)
            {
                var input = Console.ReadLine();

                if (validator.IsValid(input))
                {
                    var transformedInput = Splitter.Transform(input);
                    var result = calculator.Calc(transformedInput);

                    Console.WriteLine(result);
                }
            }
        }


    }
}
