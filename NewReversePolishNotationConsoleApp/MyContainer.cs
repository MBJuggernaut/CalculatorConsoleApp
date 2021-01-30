using Microsoft.Extensions.DependencyInjection;
using System;

namespace NewReversePolishNotationConsoleApp
{
    public class MyContainer
    {
        public static IServiceProvider Initialize()
        {
            IServiceCollection services = new ServiceCollection(); 
            services.AddSingleton<IOperationsLogicContainer, BasicOperationsLogicContainer>();
            services.AddSingleton<IValidate, Validator>();
            services.AddSingleton<IFix, Fixer>();
            services.AddSingleton<IFromPolishNotationCalculate, FromPolishNotationCalculator>();
            services.AddSingleton<IToPolishNotationParser, ToPolishNotationParser>();

            IServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
    }

}
