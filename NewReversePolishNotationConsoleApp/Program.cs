using System;

namespace NewReversePolishNotationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    Validator.Validate(ref input);

                    string expression = ToPolishNotationParser.Parse(input);

                    Console.WriteLine(Calculator.Calculate(expression));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
