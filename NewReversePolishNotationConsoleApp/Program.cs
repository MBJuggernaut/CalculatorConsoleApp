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
                    Fixer.Fix(ref input);

                    Validator.Validate(input);

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
