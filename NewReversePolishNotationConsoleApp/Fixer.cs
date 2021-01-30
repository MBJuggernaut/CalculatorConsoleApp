namespace NewReversePolishNotationConsoleApp
{
    public class Fixer : IFix
    {
        public void Fix(ref string input)
        {
            input = input.Replace(" ", "");

            input = input.Replace('.', ',');
        }
    }
}
