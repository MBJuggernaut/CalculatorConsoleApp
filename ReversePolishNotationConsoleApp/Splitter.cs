using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotationConsoleApp
{
    public class Splitter: ISplitter
    {
        private readonly string pattern;

        public Splitter(string pattern)
        {
            this.pattern = pattern;   
        }

        public Splitter()
        {
            pattern = @"-?\d+(?:\,\d+)?";
        }

        public List<object> MakeAListOfOperandsAndOperators(string input)
        {
            var output = new List<object>();
            char current;

            for (int i = 0; i < input.Length; i++)
            {
                current = input[i];
                if (char.IsDigit(current))
                {
                    GetParseAndPutToOutput(input, ref i, ref output);
                    continue;
                }
                else if (current == '-')
                {
                    if (i == 0)
                    {
                        GetParseAndPutToOutput(input, ref i, ref output);
                        continue;
                    }
                    else if (!char.IsDigit(input[i - 1]))
                    {
                        GetParseAndPutToOutput(input, ref i, ref output);
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

            return alloperands[0].Value;
        }
        private void GetParseAndPutToOutput(string input, ref int index, ref List<object> output)
        {
            var nextOperand_string = GetNextOperand(input, index);
            var nextOperand_double = double.Parse(nextOperand_string);

            output.Add(nextOperand_double);
            index += nextOperand_string.Length - 1;

        }
    }
}
