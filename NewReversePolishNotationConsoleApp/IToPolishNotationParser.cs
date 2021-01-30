namespace NewReversePolishNotationConsoleApp
{
    public interface IToPolishNotationParser
    {
        /// <summary>
        /// Возвращает строку, с переведенным в польскую запись выражением
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string Parse(string input);
    }             
}
