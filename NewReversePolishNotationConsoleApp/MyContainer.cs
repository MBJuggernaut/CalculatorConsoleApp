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
            services.AddSingleton<IValidateUserInput, InputValidator>();
            services.AddSingleton<IFixInput, InputFixer>();
            services.AddSingleton<IPolishNotationCalculate, PolishNotationCalculator>();
            services.AddSingleton<IPolishNotationParser, PolishNotationParser>();
            services.AddSingleton<ICalculate, Calculator>();

            IServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
    }

}
