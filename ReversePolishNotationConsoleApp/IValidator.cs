using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    public interface IValidator
    {
        bool IsValid(string input);        
    }
}
