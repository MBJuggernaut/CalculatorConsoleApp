namespace NewReversePolishNotationConsoleApp
{
    public interface ICalculate
    {
        double Calculate(string input);
        IFix fixer { get; }
        IValidate validator { get; }
        IToPolishNotationParser parser { get; }
        IFromPolishNotationCalculate calculator { get; }
    }

}
