namespace NewReversePolishNotationConsoleApp
{
    /// <summary>
    /// Проверяет, все ли подходит по правилам ввода
    /// </summary>
    public interface IValidateUserInput
    {
        bool IsValid(string input);
    }
}
