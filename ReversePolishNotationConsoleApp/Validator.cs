using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ReversePolishNotationConsoleApp
{
    public class Validator: IValidator
    {
        private string pattern;
        private string ErrorMessage;
        List<char> operators;


        private Action<string> method;

        public Validator(Action<string> method)
        {
            pattern = @"-?\d+(?:\,\d+)?";
            this.method = method;
            List<char> operators = new List<char>() { '(', ')', '*', '/', '+', '-', ',' };
        }
        public Validator(string newPattern, Action<string> method)
        {
            this.method = method;
            this.pattern = newPattern ?? @"-?\d+(?:\,\d+)?";            
        }
        public Validator(List<char> operators, Action<string> method)
        {
            this.method = method;
            this.operators = operators;
        }
        public bool IsValid(string input)
        {
            return ContainsOnlyAllowedSymbols(input) && ContainsRightAmountOfBrackets(input) && !ContainsExtraComma(input);
        }
        private bool ContainsRightAmountOfBrackets(string input)
        {
            int countOfOpeningBrackets = input.Count(x => x == '(');
            int countOfClosingBrackets = input.Count(x => x == ')');

            if (!(countOfOpeningBrackets == countOfClosingBrackets))
            {
                ErrorMessage = "Открывающих и закрывающих скобок должно быть одинаковое количество";
                return false;
            }
            return true;
        }
        private bool ContainsOnlyAllowedSymbols(string input)
        {
            char current;
            List<char> allowedSymbols = new List<char>() { '(', ')', '*', '/', '+', '-', ',' };

            for (int i = 0; i < input.Length; i++)
            {
                current = input[i];

                if (char.IsDigit(current))
                    continue;
                if (char.IsLetter(current))
                {
                    ErrorMessage = "Строка не должна содержать букв";
                    return false;
                }
                if (!allowedSymbols.Contains(current))
                {
                    ErrorMessage = "Строка содержит символы, которых быть не должно";
                    return false;
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
                ErrorMessage = "Кажется, у вас были лишние запятые";
                return true;
            }

            return false;
        }
        public void ShowError()
        {
            method?.Invoke(ErrorMessage);
        }
        public void FixInput(ref string input)
        {
            input = input.Trim();

            input = input.Replace('.', ',');

            input = input.Replace("--", "");


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

