using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    public class Calculator: ICalculate
    {
        private Stack<double> operands;
        private Stack<char> operations;               

        public double Calc(List<object> input)
        {
            operands = new Stack<double>();
            operations = new Stack<char>();

            Dictionary<char, int> levelsOfImportanceForOperations = new Dictionary<char, int>()
            {
                ['+'] = 1,
                ['-'] = 1,
                ['*'] = 2,
                ['/'] = 2,
                ['%'] = 2
            };

            foreach (var item in input)
            {
                if (item.GetType() == typeof(double))
                {
                    operands.Push((double)item);
                }
                else
                {
                    if (operations.Count == 0) //если стек пуст
                    {
                        operations.Push((char)item);
                    }

                    else if ((char)item=='(')
                    {
                        operations.Push((char)item);
                    }
                    else if ((char)item == ')')
                    {
                        char last = operations.Pop();

                        while (last != '(')
                        {
                            var op = last;
                            HandleOperation(op);

                            last = operations.Pop();
                        }
                    }

                    else //определяем и совершаем действие
                    {

                        levelsOfImportanceForOperations.TryGetValue(operations.Peek(), out int lastOperationFromStackQueue);
                        levelsOfImportanceForOperations.TryGetValue((char)item, out int thisOperationQueue);

                        if (lastOperationFromStackQueue >= thisOperationQueue)
                        {
                            var op = operations.Pop();

                            HandleOperation(op);

                            operations.Push((char)item);
                        }
                        else
                        {
                            operations.Push((char)item);
                        }
                    }

                }
            }

            while (operations.Count != 0)
            {
                var op = operations.Pop();

                if (operands.Count >= 2)
                {
                    HandleOperation(op);
                }
                else
                {
                    throw new Exception("Мало операндов");
                }
            }

            if (operands.Count == 1)
            {
                double result = operands.Pop();
                return result;
            }

            else
            {
                throw new Exception("Много операндов");
            }
        }
        private void HandleOperation(char op)
        {

            if (operands.TryPop(out double secondOperand) && operands.TryPop(out double firstOperand))
            {
                double resultOfoperation = 0;
                switch (op)
                {
                    case '+': resultOfoperation = firstOperand + secondOperand; break;
                    case '-': resultOfoperation = firstOperand - secondOperand; break;
                    case '*': resultOfoperation = firstOperand * secondOperand; break;
                    case '/': resultOfoperation = firstOperand / secondOperand; break;
                    case '%': resultOfoperation = firstOperand % secondOperand; break;
                }

                operands.Push(resultOfoperation);
            }
        }
    }
}
