using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public static class Calculator
    {
        public static double Calculate(string input)
        {
            double result = 0; //Результат
            Func<double, double, double> operation;
            Stack<double> temp = new Stack<double>(); //Dhtvtyysq стек для решения

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
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    operation = LogicContainer.PickAction(input[i]);
                    if(operation!=null)
                    result = operation.Invoke(b, a);

                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }
        private static bool IsOperator(char symbol)
        {
            return LogicContainer.OperationsAndTheirImportance.ContainsKey(symbol);
        }
        private static byte GetPriority(char thisOperator)
        {
            byte i;
            LogicContainer.OperationsAndTheirImportance.TryGetValue(thisOperator, out i);
            return i;
        }
    }
}
