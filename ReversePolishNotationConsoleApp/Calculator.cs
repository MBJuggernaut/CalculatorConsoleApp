using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    public class Calculator: ICalculator
    {
        private Stack<double> operands;
        private Stack<char> operations;
        private readonly Dictionary<char, int> levelsOfImportanceForOperations = new Dictionary<char, int>()
        {
            ['+'] = 1,
            ['-'] = 1,
            ['*'] = 2,
            ['/'] = 2
        };        

        public double Calc(List<object> input)
        {
            operands = new Stack<double>();
            operations = new Stack<char>();

            foreach (var item in input)
            {
                if (IsOperand(item))
                {
                    operands.Push((double)item);
                }
                else
                {
                    char thisOperator = (char)item;

                    if (operations.Count == 0)
                    {
                        operations.Push(thisOperator);
                    }

                    else if (thisOperator == '(')
                    {
                        operations.Push(thisOperator);
                    }
                    else if (thisOperator == ')')
                    {
                        DoWhatIsBetweenBrackets();                        
                    }
                    else
                    {
                        ChooseAndDoNextAction(thisOperator);                        
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
                throw new Exception("Недостаточно операций");
            }
        }
        /// <summary>
        /// Делаем все операции из стека, пока не дойдем до открывающей скобки
        /// </summary>
        private void DoWhatIsBetweenBrackets()
        {
            char last = operations.Pop();

            while (last != '(')
            {
                var operationToHandle = last;
                HandleOperation(operationToHandle);

                last = operations.Pop();
            }
        }

        /// <summary>
        /// Исходя из заданной важности операций решаем, отправить текущую оперцию в стек, или проделать уже лежащие в стеке более важные операции
        /// </summary>
        private void ChooseAndDoNextAction(char thisOperator)
        {
            
            levelsOfImportanceForOperations.TryGetValue(operations.Peek(), out int lastOperationFromStackQueue);
            levelsOfImportanceForOperations.TryGetValue(thisOperator, out int thisOperationQueue);

            if (lastOperationFromStackQueue >= thisOperationQueue)
            {
                var op = operations.Pop();

                HandleOperation(op);

                operations.Push(thisOperator);
            }
            else
            {
                operations.Push(thisOperator);
            }
        }
        private void HandleOperation(char operationToHandle)
        {

            if (operands.TryPop(out double secondOperand) && operands.TryPop(out double firstOperand))
            {
                double resultOfoperation = 0;
                switch (operationToHandle)
                {
                    case '+': resultOfoperation = firstOperand + secondOperand; break;
                    case '-': resultOfoperation = firstOperand - secondOperand; break;
                    case '*': resultOfoperation = firstOperand * secondOperand; break;
                    case '/': resultOfoperation = firstOperand / secondOperand; break;                   
                }

                operands.Push(resultOfoperation);
            }
        }
        private bool IsOperand(object item)
        {
            return item.GetType() == typeof(double);
        }


        
    }
}
