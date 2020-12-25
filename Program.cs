using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CalculatorConsoleApp
{
    class Program
    {
        readonly static string pattern = @"-?\d+(?:\.\d+)?";
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();//получаем запрос, нужно более общее

                if (IsValid(ref input))
                    Console.WriteLine(Culc(input));

                else
                    continue;
            }
        }
        private static string Culc(string input)
        {
            while (input.Contains('('))
            {
                string toreplace = GetWhatIsBetweenBrackets(input, input.LastIndexOf('('));
                string toreplacewith = Culc(toreplace);

                input = input.Replace($"({toreplace})", toreplacewith);

                IsValid(ref input);
            }
            while (input.Contains('*'))
            {
                int index = input.IndexOf('*');
                double leftoperand = GetLeftOperand(input, index);
                double rightoperand = GetRightOperand(input, index);

                string toreplace = $"{leftoperand}*{rightoperand}";
                string toreplacewith = (leftoperand * rightoperand).ToString();

                input = input.Replace(toreplace, toreplacewith);
            }
            while (input.Contains('/'))
            {
                int index = input.IndexOf('/');
                double leftoperand = GetLeftOperand(input, index);
                double rightoperand = GetRightOperand(input, index);

                string toreplace = $"{leftoperand}/{rightoperand}";
                string toreplacewith = (leftoperand / rightoperand).ToString();

                input = input.Replace(toreplace, toreplacewith);
            }

            var alloperands = Regex.Matches(input, pattern);
            if (alloperands.Count > 1)
            {
                double sum = 0;
                for (int i = 0; i < alloperands.Count; i++)
                {
                    double operand = Convert.ToDouble(alloperands[i].Value, CultureInfo.InvariantCulture);
                    sum += operand;
                }

                input = sum.ToString();
            }

            return input;
        }
        private static bool IsValid(ref string input)
        {
            input = input.Trim();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    Console.WriteLine("Строка не должна содержать букв");
                    return false;
                }
            }

            if (input.Contains("--"))
            {
                input = input.Replace("--", "+");
            }

            return true;
        }
        private static double GetLeftOperand(string input, int index)
        {
            string leftpartofinput = input.Substring(0, index);

            var alloperands = Regex.Matches(leftpartofinput, pattern);

            var numberofoperands = alloperands.Count;

            if (numberofoperands == 0)
            {
                Console.WriteLine("Не было левого операнда");
                return 0;
            }
            double operand = Convert.ToDouble(alloperands[numberofoperands - 1].Value, CultureInfo.InvariantCulture);

            return operand;
        }
        private static double GetRightOperand(string input, int index)
        {
            string rightpartofinput = input.Substring(index + 1);

            var alloperands = Regex.Matches(rightpartofinput, pattern);

            if (alloperands.Count == 0)
            {
                Console.WriteLine("Не было правого операнда");
                throw new Exception();
            }

            double operand = Convert.ToDouble(alloperands[0].Value, CultureInfo.InvariantCulture);

            return operand;
        }
        private static string GetWhatIsBetweenBrackets(string input, int index)
        {
            string str = "";

            int numberofbrackets = 1;

            for (int j = index + 1; j < input.Length; j++)
            {
                if (input[j] == '(')
                {
                    numberofbrackets++;
                }
                else if (input[j] == ')')
                {
                    numberofbrackets--;
                }

                if (numberofbrackets == 0)
                    break;

                str += input[j];
            }
            return str;
        }
    }
}
