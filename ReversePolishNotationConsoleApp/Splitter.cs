using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotationConsoleApp
{
    public class Splitter : ISplitter
    {
        private readonly string pattern = @"-?\d+(?:\,\d+)?";
        private List<object> output;

        public List<object> SeparateOperandsAndOperators(string input)
        {            
            char current;
            output = new List<object>();

            for (int i = 0; i < input.Length; i++)
            {
                current = input[i];
                if (char.IsDigit(current))
                {
                    GetParseAndPutToOutput(input, ref i);
                    continue;
                }
                else if (current == '-')
                {
                    if (i == 0)
                    {
                        GetParseAndPutToOutput(input, ref i);
                        continue;
                    }
                    else if (!char.IsDigit(input[i - 1]))
                    {
                        GetParseAndPutToOutput(input, ref i);
                        continue;
                    }
                    else
                    {
                        output.Add(current);
                        continue;
                    }
                }
                else
                {
                    output.Add(current);
                    continue;
                }
            }
            return output;
        }
        public string GetNextOperand(string input, int index)
        {
            string rightpartofinput = input.Substring(index);

            var alloperands = Regex.Matches(rightpartofinput, pattern);

            if (alloperands.Count > 0)
                return alloperands[0].Value;

            else
            {
                throw new Exception("Не найден операнд");
            }
        }
        private void GetParseAndPutToOutput(string input, ref int index)
        {
            var nextOperand_string = GetNextOperand(input, index);

            if (double.TryParse(nextOperand_string, out double nextOperand_double))
            {

                output.Add(nextOperand_double);
                index += nextOperand_string.Length - 1;
            }

        }
    }
}
