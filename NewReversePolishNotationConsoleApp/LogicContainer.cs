using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public static class LogicContainer
    {
        public static Dictionary<char, byte> OperationsAndTheirImportance;

        static LogicContainer()
        {
            OperationsAndTheirImportance = new Dictionary<char, byte>()
            {
                ['('] = 0,
                [')'] = 0,
                ['+'] = 1,
                ['-'] = 1,
                ['*'] = 2,
                ['/'] = 2
            };
        }
        public static Func<double, double, double> PickAction(char thisOperator)
        {
            Func<double, double, double> operation;
            switch (thisOperator)
            {
                case '+': operation = (double firstOperand, double secondOperand) => firstOperand + secondOperand; break;
                case '-': operation = (double firstOperand, double secondOperand) => firstOperand - secondOperand; break;
                case '*': operation = (double firstOperand, double secondOperand) => firstOperand * secondOperand; break;
                case '/': operation = (double firstOperand, double secondOperand) => firstOperand / secondOperand; break;
                default: operation = null; break;
            }

            return operation;
        }
        static public byte GetPriority(char s)
        {
            byte i;
            OperationsAndTheirImportance.TryGetValue(s, out i);
            return i;
        }
    }
}
