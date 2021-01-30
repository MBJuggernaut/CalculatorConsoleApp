using Microsoft.Extensions.DependencyInjection;
using System;

namespace NewReversePolishNotationConsoleApp
{
    public class Calculator: ICalculate
    {        
        public IFix fixer { get; }
        public IValidate validator { get; }
        public IToPolishNotationParser parser { get; }
        public IFromPolishNotationCalculate calculator { get; }

        public Calculator(IServiceProvider provider)
        {
            fixer = provider.GetService<IFix>();
            validator = provider.GetService<IValidate>();
            parser = provider.GetService<IToPolishNotationParser>();
            calculator = provider.GetService<IFromPolishNotationCalculate>();

        }

        public double Calculate(string input)
        {
            fixer.Fix(ref input);
            if (validator.IsValid(input))
            {
                string expression = parser.Parse(input);
                return calculator.Calculate(expression);
            }

            throw new Exception("Не получилось посчитать значение выражения");
        }
    }

}
