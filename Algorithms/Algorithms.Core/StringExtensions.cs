using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class StringExtensions
    {
        public static List<string> GetCombinations(this string str)
        {
            List<string> l = new List<string>();
            GetCombinations(l, str.ToCharArray(), 0, str.Length - 1);
            return l;
        }

        private static void GetCombinations(List<string> list, char[] chars, int index, int high)
        {
            if (index == high)
                list.Add(new String(chars));
            else
                for (int i = index; i <= high; i++)
                {
                    Swap(chars, i, index);
                    GetCombinations(list, chars, index + 1, high);
                    Swap(chars, index, i);
                }
        }

        private static void Swap(char[] arr, int p1, int p2)
        {
            char tmp = arr[p1];
            arr[p1] = arr[p2];
            arr[p2] = tmp;            
        }
    }
}
