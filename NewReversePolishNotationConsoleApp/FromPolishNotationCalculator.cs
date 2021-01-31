using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public class FromPolishNotationCalculator : IFromPolishNotationCalculate
    {

        IOperationsLogicContainer logicContainer;

        public FromPolishNotationCalculator(IOperationsLogicContainer logicContainer)
        {
            this.logicContainer = logicContainer;
        }

        public double Calculate(string input)
        {
            string[] s = input.Split(" ");
            double result = 0; //Результат            
            Stack<double> temp = new Stack<double>(); // Стек для решения

            for (int i = 0; i < s.Length; i++) //Для каждого символа в строке
            {
                if (s[i] == "")
                {
                    continue;
                }
                //Если число, то записываем его в стек 
                if (double.TryParse(s[i], out result))
                {
                    temp.Push(result);
                    continue;
                }
                //Если не число, то считаем, и записываем
                else
                {
                    double firstOperand, secondOperand = 0;
                    //Берем два последних значения из стека
                    temp.TryPop(out secondOperand);
                    temp.TryPop(out firstOperand);
                    result = logicContainer.PerformOperation(Char.Parse(s[i]), firstOperand, secondOperand);//Считаем

                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Возвращаем результат всех вычислений из стека
        }
    }
}
