﻿using System;

namespace ReversePolishNotationConsoleApp
{
    public class Program
    {           
        static void Main()
        {                        
            IValidator validator = new Validator();
            ICalculator calculator = new Calculator();
            ISplitter splitter = new Splitter();

            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    validator.IsValid(input);
                    var splittedInput = splitter.MakeAListOfOperandsAndOperators(input);
                    Console.WriteLine(calculator.Calc(splittedInput));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }            
        }


    }
}
