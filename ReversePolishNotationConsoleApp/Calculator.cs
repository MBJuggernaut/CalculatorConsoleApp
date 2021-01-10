using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    public static class Calculator
    {
        static Stack<double> operands = new Stack<double>();
        static Stack<string> stackOfOperations = new Stack<string>();
        
        public static double Calc(List<object> input)
        {
            operands = new Stack<double>();
            stackOfOperations = new Stack<string>();

            Dictionary<string, int> dict = new Dictionary<string, int>()
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
                    operands.Push((double)item);
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

                    else //определяем действие
                    {
                        int lastOperationFromStackQueue, thisOperationQueue;
                        var lastOperationFromStack = stackOfOperations.Peek();

                        dict.TryGetValue(lastOperationFromStack, out lastOperationFromStackQueue);
                        dict.TryGetValue(item.ToString(), out thisOperationQueue);

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

                if (operands.Count >= 2)
                {
                    HandleOperation(op);
                }
                else
                {
                    //ошибка мало операндов
                    Console.WriteLine("ошибка мало операндов");
                    break;
                }
            }

            if (operands.Count == 1)
            {
                double result = operands.Pop();
                return result;
            }

            else
            {
                //ошибка много операндов
                return -1;
            }
        }

        private static void HandleOperation(string op)
        {
            double firstOperand, secondOperand;

            if (operands.TryPop(out secondOperand) && operands.TryPop(out firstOperand))
            {
                double resultOfoperation = 0;
                switch (op)
                {
                    case "+": resultOfoperation = Sum(firstOperand, secondOperand); break;
                    case "-": resultOfoperation = Substract(firstOperand, secondOperand); break;
                    case "*": resultOfoperation = Multiply(firstOperand, secondOperand); break;
                    case "/": resultOfoperation = Divide(firstOperand, secondOperand); break;
                }

                operands.Push(resultOfoperation);
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
    }
}
