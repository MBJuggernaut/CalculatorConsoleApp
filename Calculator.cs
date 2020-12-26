using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorConsoleApp
{
    public class Calculator
    {
        private static string pattern = @"-?\d+(?:\,\d+)?";

        public Calculator(string pattern)
        {
            Calculator.pattern = pattern ?? Calculator.pattern;
        }
        /// <summary>
        /// Метод принимает выражение в виде строки.
        /// Алгоритм обработки:
        /// 1) Разбирается с содержимым всех скобок;
        /// 2) Производит все умножения и деления в том порядке, в котором они идут в выражении;
        /// 3) Разбивает оставшееся выражение на операнды, и складывает их все.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Calc(string input)
        {
            HandleAllBrackets(ref input);
            HandleAllMultiplyAndDivide(ref input);
            HandleAllSumsAndSubtractions(ref input);

            return input;
        }
        private static double GetLeftOperand(string input, int index)
        {
            string leftpartofinput = input.Substring(0, index);

            var alloperands = Regex.Matches(leftpartofinput, pattern);

            var numberofoperands = alloperands.Count;

            double operand = Convert.ToDouble(alloperands[numberofoperands - 1].Value, CultureInfo.CurrentCulture);

            return operand;
        }
        private static double GetRightOperand(string input, int index)
        {
            string rightpartofinput = input.Substring(index + 1);

            var alloperands = Regex.Matches(rightpartofinput, pattern);

            double operand = Convert.ToDouble(alloperands[0].Value, CultureInfo.CurrentCulture);

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
        private static void HandleAllMultiplyAndDivide(ref string input)
        {
            int asterixIndex, slashIndex;

            while (input.Contains('*') || input.Contains('/'))
            {
                asterixIndex = input.IndexOf('*');
                slashIndex = input.IndexOf('/');
                if (asterixIndex == -1)
                {
                    Divide(ref input, slashIndex);
                }
                else if (slashIndex == -1 || asterixIndex < slashIndex)
                {
                    Multiply(ref input, asterixIndex);
                }
                else
                {
                    Divide(ref input, slashIndex);
                }
            }
        }
        public static void Multiply(ref string input, int index)
        {
            double leftoperand = GetLeftOperand(input, index);
            double rightoperand = GetRightOperand(input, index);

            string toreplace = $"{leftoperand}*{rightoperand}";
            string toreplacewith = (leftoperand * rightoperand).ToString();
            input = input.Replace(toreplace, toreplacewith);
        }
        public static void Divide(ref string input, int index)
        {
            double leftoperand = GetLeftOperand(input, index);
            double rightoperand = GetRightOperand(input, index);

            string toreplace = $"{leftoperand}/{rightoperand}";
            string toreplacewith = (leftoperand / rightoperand).ToString();

            input = input.Replace(toreplace, toreplacewith);
        }
        /// <summary>
        /// Пока в выражении есть скобки, метод находит и обрабатывает методом Calc их содержимое
        /// </summary>
        /// <param name="input"></param>
        private static void HandleAllBrackets(ref string input)
        {
            while (input.Contains('('))
            {
                int index = input.LastIndexOf('(');

                string toreplace = GetWhatIsBetweenBrackets(input, index);

                string toreplacewith = Calc(toreplace);

                input = input.Replace($"({toreplace})", toreplacewith);
            }

            input = input.Replace("--", "+");
        }
        /// <summary>
        /// Метод разбивает выражение на операнды и заменяет выражение их суммой
        /// </summary>
        /// <param name="input"></param>
        private static void HandleAllSumsAndSubtractions(ref string input)
        {
            input = input.Trim('+');

            var alloperands = Regex.Matches(input, pattern);
            if (alloperands.Count > 1)
            {
                double sum = 0;
                for (int i = 0; i < alloperands.Count; i++)
                {
                    double operand = Convert.ToDouble(alloperands[i].Value, CultureInfo.CurrentCulture);
                    sum += operand;
                }

                input = sum.ToString();
            }
        }


    }
}
