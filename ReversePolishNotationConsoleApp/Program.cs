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
            var input = Console.ReadLine();

            var y = Splitter.Split(input);

            var z = Parser.Parse(y);

            var result = Calculator.Calc(z);

            Console.WriteLine(result);
        }


    }
}
