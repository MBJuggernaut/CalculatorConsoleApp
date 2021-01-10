using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationConsoleApp
{
    public interface ICalculator
    {
        double Calc(List<object> input);
        bool TryToCalc(List<object> input, out double result);
        void ShowError();
    }
}
