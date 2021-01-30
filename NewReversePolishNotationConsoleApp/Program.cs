using System;

namespace NewReversePolishNotationConsoleApp
{
    class Program
    {
        static void Main()
        {
            var provider = MyContainer.Initialize();
            ICalculate calculator = new Calculator(provider);

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
