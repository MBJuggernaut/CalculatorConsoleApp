using System;


namespace CalculatorConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Action<string> method = (message) => { Console.WriteLine(message); };
            Validator validator = new Validator(method);            

            while (true)
            {
                string input = Console.ReadLine();
                validator.FixInput(ref input);

                if (validator.IsValid(input))
                    Console.WriteLine(Calculator.Calc(input));

                else
                    validator.ShowError();
                continue;
            }
        }

    }
}
