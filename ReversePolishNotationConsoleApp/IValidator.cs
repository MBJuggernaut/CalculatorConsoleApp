using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    interface IValidator
    {
        bool IsValid(string input);
        void ShowError();
    }
}
