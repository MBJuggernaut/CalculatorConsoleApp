using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public static class Calculator
    {
        public static double Calculate(string input)
        {
            double result = 0; //Результат            
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsOperator(input[i]) && input[i] != ' ') //Пока это часть числа
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
                    result = OperationsLogicContainer.PerformOperation(input[i], firstOperand, secondOperand);//Считаем

                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Возвращаем результат всех вычислений из стека
        }
        private static bool IsOperator(char symbol)
        {
            return OperationsLogicContainer.OperationsAndTheirImportance.ContainsKey(symbol);
        }
        private static byte GetPriority(char thisOperator)
        {
            byte i;
            OperationsLogicContainer.OperationsAndTheirImportance.TryGetValue(thisOperator, out i);
            return i;
        }
    }
}
