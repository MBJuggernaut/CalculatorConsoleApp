using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public static class ToPolishNotationParser
    {
        public static string Parse(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов
            

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                if (Char.IsDigit(input[i])) //Если цифра или запятая
                {
                    //Читаем до разделителя или оператора, что бы получить число
                    while (!IsOperator(input[i]))
                    {
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        i++; //Переходим к следующему символу   
                        if (i == input.Length) break;
                    } 

                    output += " "; //Дописываем после числа пробел в строку с выражением
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }
                if (IsOperator(input[i])) //Если оператор
                {
                    if (input[i] == '(') //Если символ - открывающая скобка
                        operStack.Push(input[i]); //Записываем её в стек
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0) //Если в стеке есть элементы
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                        operStack.Push(input[i]); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека
                    }
                }
            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
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
