using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public class ToPolishNotationParser : IToPolishNotationParser
    {
        IOperationsLogicContainer logicContainer;

        public ToPolishNotationParser(IOperationsLogicContainer logicContainer)
        {
            this.logicContainer = logicContainer;
        }

        public string Parse(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов


            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                if (Char.IsDigit(input[i])) //Если цифра
                {
                    string temp = GetNextOperand(input, i);
                    output += temp;
                    i += temp.Length-1;

                    output += " "; //Дописываем после числа пробел в строку с выражением
                    
                    continue;
                }
                if (IsOperator(input[i]))
                {
                    if (input[i] == '-')
                    {
                        if (i == 0 || !char.IsDigit(input[i - 1]))
                        {
                            if (char.IsDigit(input[i + 1]))
                            {
                                string temp = GetNextNegativeOperand(input, i);
                                output += temp;
                                i += temp.Length - 1;

                                output += " ";

                                continue;
                            }
                        }                        
                        if (operStack.Count > 0) //Если в стеке есть элементы
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                        operStack.Push(input[i]);
                    }
                    else if (input[i] == '(') //Если символ - открывающая скобка
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
        
        private string GetNextOperand(string input, int i)
        {
            string operand = "";

            while (!IsOperator(input[i]))
            {
                operand += input[i]; //Добавляем каждую цифру числа к нашей строке
                i++; //Переходим к следующему символу   
                if (i == input.Length) break;
            }

            return operand;
        }

        private string GetNextNegativeOperand(string input, int i)
        {
            string operand = "-";                        
            operand += GetNextOperand(input, ++i);
            return operand;
        }

        private bool IsOperator(char symbol)
        {
            return logicContainer.OperationsAndTheirImportance.ContainsKey(symbol);
        }
        private byte GetPriority(char thisOperator)
        {
            byte i;
            logicContainer.OperationsAndTheirImportance.TryGetValue(thisOperator, out i);
            return i;
        }

    }
}
