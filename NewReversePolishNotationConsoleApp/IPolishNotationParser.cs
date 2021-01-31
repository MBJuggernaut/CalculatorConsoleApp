namespace NewReversePolishNotationConsoleApp
{
    public interface IPolishNotationParser
    {
        /// <summary>
        /// Возвращает строку, с переведенным в польскую запись выражением
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string Parse(string input);
    }             
}
