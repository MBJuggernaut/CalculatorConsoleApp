using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ReversePolishNotationConsoleApp
{
    public class Validator: IValidator
    {
        private readonly string pattern;
        private readonly List<char> operators;

        public Validator()
        {
            pattern = @"-?\d+(?:\,\d+)?";
            operators = new List<char>() { '(', ')', '*', '/', '+', '-', ',' };
        }
        public Validator(string newPattern)
        {            
            this.pattern = newPattern ?? @"-?\d+(?:\,\d+)?";            
        }
        public Validator(List<char> operators)
        {            
            this.operators = operators;
        }
        public bool IsValid(string input)
        {
            FixInput(ref input);
            return ContainsOnlyAllowedSymbols(input) && ContainsRightAmountOfBrackets(input) && !ContainsExtraComma(input);
        }
        private bool ContainsRightAmountOfBrackets(string input)
        {
            int countOfOpeningBrackets = input.Count(x => x == '(');
            int countOfClosingBrackets = input.Count(x => x == ')');

            if (!(countOfOpeningBrackets == countOfClosingBrackets))
            {               
                throw new Exception("Открывающих и закрывающих скобок должно быть одинаковое количество");               
            }
            return true;
        }
        private bool ContainsOnlyAllowedSymbols(string input)
        {
            char current;           

            for (int i = 0; i < input.Length; i++)
            {
                current = input[i];

                if (char.IsDigit(current))
                    continue;
                if (char.IsLetter(current))
                {
                    throw new Exception("Строка не должна содержать букв");                    
                }
                if (!operators.Contains(current))
                {                    
                    throw new Exception("Строка содержит символы, которых быть не должно");                    
                }
            }

            return true;
        }
        private bool ContainsExtraComma(string input)
        {
            var alloperands = Regex.Matches(input, pattern);

            foreach (var operand in alloperands)
            {
                input = input.Replace(operand.ToString(), "");
            }

            if (input.Contains(','))
            {
                throw new Exception("Кажется, у вас были лишние запятые");                
            }

            return false;
        }
        public void FixInput(ref string input)
        {
            input = input.Replace(" ", "");

            input = input.Replace('.', ',');

            input = input.Replace("--", "+");


            for (int i = 0; i < input.Length; i++)
            {
                if (i != 0 && input[i] == '(')
                {
                    if (char.IsDigit(input[i - 1]))
                    {
                        input = input.Insert(i, "*");
                    }
                }
            }
            input = input.Replace("()", "0");
        }
    }
}

