using System.Collections.Generic;
using System.Globalization;

namespace NewReversePolishNotationConsoleApp
{
    public class PolishNotationCalculator : IPolishNotationCalculate
    {
        private readonly IOperationsLogicContainer logicContainer;

        public PolishNotationCalculator(IOperationsLogicContainer logicContainer)
        {
            this.logicContainer = logicContainer;
        }
        public double Calculate(string input)
        {
            var s = input.Split(" ");
            double result = 0;
            var operands = new Stack<double>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "")
                {
                    continue;
                }
                if (double.TryParse(s[i], NumberStyles.Any, CultureInfo.CurrentCulture, out result))
                {
                    operands.Push(result);
                    continue;
                }
                else
                {
                    double firstOperand, secondOperand = 0;
                    operands.TryPop(out secondOperand);
                    operands.TryPop(out firstOperand);
                    result = logicContainer.PerformOperation(char.Parse(s[i]), firstOperand, secondOperand);

                    operands.Push(result);
                }
            }

            if (operands.Count != 1)
            {
                throw new System.Exception("Не удалось подсчитать выражение");
            }
            return operands.Peek();
        }
    }
}
