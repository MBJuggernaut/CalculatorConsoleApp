using System;
using Microsoft.Extensions.DependencyInjection;

namespace NewReversePolishNotationConsoleApp
{
    class Program
    {
        static void Main()
        {
            var provider = MyContainer.Initialize();
            ICalculate calculator = provider.GetService<ICalculate>();
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    Console.WriteLine(calculator.Calculate(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

