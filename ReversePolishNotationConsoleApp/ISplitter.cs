using System.Collections.Generic;

namespace ReversePolishNotationConsoleApp
{
    public interface ISplitter
    {
        List<object> MakeAListOfOperandsAndOperators(string input);
    }
}