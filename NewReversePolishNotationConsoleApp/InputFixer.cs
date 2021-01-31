namespace NewReversePolishNotationConsoleApp
{
    public class InputFixer : IFixInput
    {
        public string Fix(string input)
        {
            input = input.Replace(" ", "");
            input = input.Replace('.', ',');
            return input;
        }
    }
}
