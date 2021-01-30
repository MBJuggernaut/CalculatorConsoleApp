using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public class BasicOperationsLogicContainer: IOperationsLogicContainer
    {        
       public  Dictionary<char, byte> OperationsAndTheirImportance { get;}

        public BasicOperationsLogicContainer()
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
        public BasicOperationsLogicContainer(Dictionary<char, byte> OperationsAndTheirImportance)
        {
            this.OperationsAndTheirImportance = OperationsAndTheirImportance;
        }
       
        public double PerformOperation(char thisOperator, double firstOperand, double secondOperand)
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
