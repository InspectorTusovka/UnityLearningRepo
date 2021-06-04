using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson7
{
    internal static class Extensions
    {
        internal static int StringLenght(this string self)
        {
            int result = 0;
            
            foreach (var c in self)
                if (c != ' ')
                    result++;
            
            return result;
        }

        internal static Dictionary<T, int> IdenticalElemCount<T>(this List<T> self)
        {
            var result = new Dictionary<T, int>();

            foreach (var elem in self)
                if (result.ContainsKey(elem)) result[elem]++;
                else
                    result.Add(elem, 1);

            return result;
        }

        internal static void ShowUniqElem<T>(this Dictionary<T, int> self)
        {
            foreach (var elem in self.Keys.ToList()) 
                Console.WriteLine($"Элемент {elem} встречается {self[elem]} раз");
        }
    }
}