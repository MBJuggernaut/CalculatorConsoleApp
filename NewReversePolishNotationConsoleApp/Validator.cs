using System;

namespace NewReversePolishNotationConsoleApp
{
    public static class Validator
    {
        public static bool Validate(string input)
        {
            return ContainsOnlyAllowedSymbols(input) && BracketsAreAlright(input) && !ContainsExtraComma(input);
        }
        private static bool BracketsAreAlright(string input)
        {
            int openingBracketsCount = 0;
            int closingBracketsCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openingBracketsCount++;
                }
                if (input[i] == ')')
                {
                    if (openingBracketsCount > closingBracketsCount)
                        closingBracketsCount++;
                    else throw new Exception("Закрывающая скобка не должна идти раньше открывающей");
                }

            }
            if (openingBracketsCount != closingBracketsCount)
                throw new Exception("Открывающих и закрывающих скобок должно быть одинаковое количество");

            return true;
        }
        private static bool ContainsOnlyAllowedSymbols(string input)
        {
            char current;

            for (int i = 0; i < input.Length; i++)
            {
                current = input[i];

                if (char.IsDigit(current) || current == ',')
                    continue;
                if (char.IsLetter(current))
                {
                    throw new Exception("Строка не должна содержать букв");
                }
                if (!OperationsLogicContainer.OperationsAndTheirImportance.ContainsKey(current))
                {
                    throw new Exception("Строка содержит символы, которых быть не должно");
                }
            }

            return true;
        }
        private static bool ContainsExtraComma(string input)
        {
            string s = String.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                while (char.IsDigit(input[i]) || input[i] == ',')
                {
                    if (input[i] == ',' && (s.Contains(input[i])||s==String.Empty))
                    {
                        throw new Exception("Слишком много запятых в одном из операндов");
                    }
                    s += input[i];
                    i++;
                    if (i == input.Length) break;
                };
                s = String.Empty;
            }

            return false;
        }
    }
}
