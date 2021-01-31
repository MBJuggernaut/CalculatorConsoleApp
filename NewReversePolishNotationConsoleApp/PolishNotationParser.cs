using System;
using System.Collections.Generic;

namespace NewReversePolishNotationConsoleApp
{
    public class PolishNotationParser : IPolishNotationParser
    {
        private readonly IOperationsLogicContainer logicContainer;

        public PolishNotationParser(IOperationsLogicContainer logicContainer)
        {
            this.logicContainer = logicContainer;
        }
        public string Parse(string input)
        {
            string output = string.Empty; 
            Stack<char> operatorsStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string temp = GetNextOperand(input, i);
                    output += temp;
                    i += temp.Length - 1;

                    output += " ";

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
                    }
                    else if (input[i] == '(')
                    {
                        operatorsStack.Push(input[i]);
                        continue;
                    }

                    else if (input[i] == ')')
                    {                        
                        char s = operatorsStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operatorsStack.Pop();
                        }
                        continue;
                    }
                    
                    if (operatorsStack.Count > 0) 
                        if (GetPriority(input[i]) <= GetPriority(operatorsStack.Peek()))
                            output += operatorsStack.Pop().ToString() + " ";

                    operatorsStack.Push(input[i]);
                }
            }

            while (operatorsStack.Count > 0)
                output += operatorsStack.Pop() + " ";

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
