namespace NewReversePolishNotationConsoleApp
{
    /// <summary>
    /// Объединяет в себе функционал остальных классов
    /// </summary>
    public interface ICalculate
    {
        double Calculate(string input);
        IFixInput InputFixer { get; }
        IValidateUserInput InputValidator { get; }
        IPolishNotationParser PolishNotationParser { get; }
        IPolishNotationCalculate PolishNotationCalculator { get; }
    }

}
