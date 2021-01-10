using System;
using System.Collections.Generic;

namespace ReversePolishNotationConsoleApp
{
    public class Program
    {
        //static string pattern = @"-?\d+(?:\,\d+)?";        
        static List<char> operators = new List<char>() { '(', ')', '*', '/', '+', '-', ',' };

       
        static void Main(string[] args)
        {
            Action<string> method = (message) => { Console.WriteLine(message); };
            Validator validator = new Validator(method);
            var input = Console.ReadLine();

            if (validator.IsValid(input)) { }

            var transformedInput = Splitter.Transform(input);
            var result = Calculator.Calc(transformedInput);

            Console.WriteLine(result);
        }


    }
}
