using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    public static class Calculator
    {
        static Stack<double> doubles = new Stack<double>();
        static Stack<string> stack = new Stack<string>();


        public static double Calc(List<object> input)
        {
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
                    doubles.Push((double)item);
                }
                else
                {
                    if(item.ToString() == ")"|| item.ToString() == "(")
                    {
                        if (item.ToString() == "(")
                        {
                            stack.Push(item.ToString());
                        }
                        else
                        {
                            string last = stack.Pop();

                            while (last != "(")
                            {
                                var op = last;
                                HandleOperation(op);

                                last = stack.Pop();
                            }
                        }
                    }
                    else if (stack.Count != 0)
                    {

                        int x, y;
                        var last = stack.Peek();

                        dict.TryGetValue(last, out x);
                        dict.TryGetValue(item.ToString(), out y);

                        if (x >= y)
                        {
                            var op = stack.Pop();

                            HandleOperation(op);

                            stack.Push(item.ToString());
                        }
                        else
                        {
                            stack.Push(item.ToString());
                        }
                    }
                    else
                    {
                        stack.Push(item.ToString());
                    }
                }

            }

            while (stack.Count != 0)
            {
                var op = stack.Pop();

                HandleOperation(op);
            }

            double result = doubles.Pop();
            return result;
        }

        private static void HandleOperation(string op)
        {
            double y = doubles.Pop();
            double x = doubles.Pop();
            switch (op)
            {
                case "+": Sum(x, y); break;
                case "-": Substract(x, y); break;
                case "*": Multiply(x, y); break;
                case "/": Divide(x, y); break;
            }
        }

        private static void Sum(double x, double y)
        {
            doubles.Push(x + y);
        }

        private static void Substract(double x, double y)
        {
            doubles.Push(x - y);
        }

        private static void Multiply(double x, double y)
        {
            doubles.Push(x * y);
        }

        private static void Divide(double x, double y)
        {
            doubles.Push(x / y);
        }
    }
}
