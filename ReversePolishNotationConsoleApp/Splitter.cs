using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotationConsoleApp
{
    public static class Splitter//разбивает введенную строку на список отдельных элементов
    {
        public static List<string> Split(string input)
        {
            var output = new List<string>();
            char current;

            for (int i = 0; i < input.Length; i++)
            {
                current = input[i];
                if (char.IsDigit(current))
                {
                    GetOperandAndPutItToOutput(input, ref i, ref output);
                    continue;
                }
                else if (current == '-')
                {
                    if (i == 0)
                    {
                        GetOperandAndPutItToOutput(input, ref i, ref output);
                        continue;
                    }
                    else if (!char.IsDigit(input[i - 1]))
                    {
                        GetOperandAndPutItToOutput(input, ref i, ref output);
                        continue;
                    }
                    else
                    {
                        output.Add(current.ToString());
                        continue;
                    }
                }
                else
                {
                    output.Add(current.ToString());
                    continue;
                }
            }            
            return output;
        }
        public static string GetNextOperand(string input, int index)
        {
            string pattern = @"-?\d+(?:\,\d+)?";

            string rightpartofinput = input.Substring(index);

            var alloperands = Regex.Matches(rightpartofinput, pattern);

            return alloperands[0].Value;
        }
        public static void GetOperandAndPutItToOutput(string input, ref int index, ref List<string> output)
        {
            var nextOperand = GetNextOperand(input, index);
            output.Add(nextOperand);
            index += nextOperand.Length - 1;

        }
    }
}
