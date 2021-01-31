namespace NewReversePolishNotationConsoleApp
{
    public interface IPolishNotationCalculate
    {
        /// <summary>
        /// Подсчитывает значение выражений в обратной польской записи
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        double Calculate(string input);
    }
}
