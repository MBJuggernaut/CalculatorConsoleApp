using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public interface IOperationsLogicContainer
    {
        public Dictionary<char, byte> OperationsAndTheirImportance { get; }
        double PerformOperation(char thisOperator, double firstOperand, double secondOperand);
    }
}
