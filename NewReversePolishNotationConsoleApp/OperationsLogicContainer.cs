using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public static class OperationsLogicContainer
    {
        public static Dictionary<char, byte> OperationsAndTheirImportance;

        static OperationsLogicContainer()
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
        public static double PerformOperation(char thisOperator, double firstOperand, double secondOperand)
        {            
            switch (thisOperator)
            {
                case '+': return firstOperand + secondOperand;
                case '-': return firstOperand - secondOperand;
                case '*': return firstOperand * secondOperand;
                case '/': return firstOperand / secondOperand;
                default: throw new Exception("Операция не найдена");
            }           
        }
    }
}
