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
            ICalculator calculator = new Calculator(method);
            while (true)
            {
                var input = Console.ReadLine();

                if (validator.IsValid(input))
                {
                    var transformedInput = Splitter.Transform(input);
                    double result;

                    if (calculator.TryToCalc(transformedInput, out result))
                        Console.WriteLine(result);

                    else calculator.ShowError();
                }

                else validator.ShowError();
            }
        }


    }
}
