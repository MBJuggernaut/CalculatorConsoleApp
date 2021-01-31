namespace NewReversePolishNotationConsoleApp
{
    public interface IFixInput
    {
        /// <summary>
        /// Исправляет небольшие ошибки ввода
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string Fix(string input);
    }
}
