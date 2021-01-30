namespace NewReversePolishNotationConsoleApp
{
    public static class Fixer
    {
        public static void Fix(ref string input)
        {
            input = input.Replace(" ", "");

            input = input.Replace('.', ',');
        }
    }
}
