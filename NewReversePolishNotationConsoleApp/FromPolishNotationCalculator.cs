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
            double result = 0; //Результат            
            Stack<double> temp = new Stack<double>(); // Стек для решения

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsOperator(input[i]) && input[i] != ' ') //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    double firstOperand, secondOperand = 0;
                    //Берем два последних значения из стека
                    temp.TryPop(out secondOperand);
                    temp.TryPop(out firstOperand);
                    result = logicContainer.PerformOperation(input[i], firstOperand, secondOperand);//Считаем

                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Возвращаем результат всех вычислений из стека
        }
        private bool IsOperator(char symbol)
        {
            return logicContainer.OperationsAndTheirImportance.ContainsKey(symbol);
        }
    }
}
