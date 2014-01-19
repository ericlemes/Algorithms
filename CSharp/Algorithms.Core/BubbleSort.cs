using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class BubbleSort
    {
        public static void Sort<T>(List<T> l) where T:IComparable
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 1; i <= l.Count - 1; i++)
                {                    
                    if ((l[i - 1]).CompareTo(l[i]) > 0)
                    {
                        l.Swap(i - 1, i);
                        swapped = true;
                    }
                }
            }
        }
    }
}
