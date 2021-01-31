using Microsoft.Extensions.DependencyInjection;
using System;

namespace NewReversePolishNotationConsoleApp
{
    public class Calculator : ICalculate
    {
        public IFixInput InputFixer { get; }
        public IValidateUserInput InputValidator { get; }
        public IPolishNotationParser PolishNotationParser { get; }
        public IPolishNotationCalculate PolishNotationCalculator { get; }

        public Calculator(IServiceProvider provider)
        {
            InputFixer = provider.GetService<IFixInput>();
            InputValidator = provider.GetService<IValidateUserInput>();
            PolishNotationParser = provider.GetService<IPolishNotationParser>();
            PolishNotationCalculator = provider.GetService<IPolishNotationCalculate>();
        }

        public double Calculate(string input)
        {
            input = InputFixer.Fix(input);
            InputValidator.IsValid(input);
            var expression = PolishNotationParser.Parse(input);
            return PolishNotationCalculator.Calculate(expression);
        }
    }

}
