using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    /// <summary>
    /// Содержит в себе список доступных команд, и их выполнение
    /// </summary>
    public interface IOperationsLogicContainer
    {
        public Dictionary<char, byte> OperationsAndTheirImportance { get; }
        double PerformOperation(char thisOperator, double firstOperand, double secondOperand);
    }
}
