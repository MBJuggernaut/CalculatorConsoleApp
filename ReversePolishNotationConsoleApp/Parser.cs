using System;
using System.Collections.Generic;

namespace ReversePolishNotationConsoleApp
{
    public static class Parser
    {
        public static List<object> Parse(List<string> list)
        {
            var parsedList = new List<object>();
            double d;
            foreach (var item in list)
            {
               if(double.TryParse(item, out d))
                {
                    parsedList.Add(d);
                }

                else
                {
                    parsedList.Add(Convert.ToChar(item));
                }
            }
            return parsedList;
        }
    }
}
