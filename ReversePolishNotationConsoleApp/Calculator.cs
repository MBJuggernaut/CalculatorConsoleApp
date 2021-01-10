using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    public class Calculator: ICalculator
    {
        static Stack<double> stackOfOperands;
        static Stack<string> stackOfOperations;
        string ErrorMessage = "";
        private Action<string> method;

        public Calculator(Action<string> method)
        {
            this.method = method;
        }

        public bool TryToCalc(List<object> input, out double result)
        {
            double d = Calc(input);

            if (ErrorMessage == "")
            {
                result = d;
                return true;                
            }

            result = 0;
            return false;
        }

        public double Calc(List<object> input)
        {
            stackOfOperands = new Stack<double>();
            stackOfOperations = new Stack<string>();

            Dictionary<string, int> levelsOfImportanceForOperations = new Dictionary<string, int>()
            {
                ["+"] = 1,
                ["-"] = 1,
                ["*"] = 2,
                ["/"] = 2
            };

            foreach (var item in input)
            {
                if (item.GetType() == typeof(double))
                {
                    stackOfOperands.Push((double)item);
                }
                else
                {
                    if (stackOfOperations.Count == 0) //если стек пуст
                    {
                        stackOfOperations.Push(item.ToString());
                    }

                    else if (item.ToString() == "(")
                    {
                        stackOfOperations.Push(item.ToString());
                    }
                    else if (item.ToString() == ")")
                    {
                        string last = stackOfOperations.Pop();

                        while (last != "(")
                        {
                            var op = last;
                            HandleOperation(op);

                            last = stackOfOperations.Pop();
                        }
                    }

                    else //определяем и совершаем действие
                    {
                        int lastOperationFromStackQueue, thisOperationQueue;
                        var lastOperationFromStack = stackOfOperations.Peek();

                        levelsOfImportanceForOperations.TryGetValue(lastOperationFromStack, out lastOperationFromStackQueue);
                        levelsOfImportanceForOperations.TryGetValue(item.ToString(), out thisOperationQueue);

                        if (lastOperationFromStackQueue >= thisOperationQueue)
                        {
                            var op = stackOfOperations.Pop();

                            HandleOperation(op);

                            stackOfOperations.Push(item.ToString());
                        }
                        else
                        {
                            stackOfOperations.Push(item.ToString());
                        }
                    }

                }
            }

            while (stackOfOperations.Count != 0)
            {
                var op = stackOfOperations.Pop();

                if (stackOfOperands.Count >= 2)
                {
                    HandleOperation(op);
                }
                else
                {
                    ErrorMessage = "Мало операндов";
                    break;
                }
            }

            if (stackOfOperands.Count == 1)
            {
                double result = stackOfOperands.Pop();
                return result;
            }

            else
            {
                ErrorMessage = "Много операндов";
                return 0;
            }
        }

        private static void HandleOperation(string op)
        {
            double firstOperand, secondOperand;

            if (stackOfOperands.TryPop(out secondOperand) && stackOfOperands.TryPop(out firstOperand))
            {
                double resultOfoperation = 0;
                switch (op)
                {
                    case "+": resultOfoperation = Sum(firstOperand, secondOperand); break;
                    case "-": resultOfoperation = Substract(firstOperand, secondOperand); break;
                    case "*": resultOfoperation = Multiply(firstOperand, secondOperand); break;
                    case "/": resultOfoperation = Divide(firstOperand, secondOperand); break;
                }

                stackOfOperands.Push(resultOfoperation);
            }
        }

        private static double Sum(double x, double y)
        {
            return x + y;
        }

        private static double Substract(double x, double y)
        {
            return x - y;
        }

        private static double Multiply(double x, double y)
        {
            return x * y;
        }

        private static double Divide(double x, double y)
        {
            return x / y;
        }

        public void ShowError()
        {
            method?.Invoke(ErrorMessage);
        }
    }
}
