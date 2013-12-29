using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class SelectionSort
    {
        public static void Sort<T>(IList<T> l) where T : IComparable
        {
            for (int i = 1; i <= l.Count - 1; i++)
            {                
                int j = i;
                while (j > 0 && l[j].CompareTo(l[j - 1]) < 0)
                {
                    l.Swap(j - 1, j);
                    j--;
                }
            }
        }
    }
}
