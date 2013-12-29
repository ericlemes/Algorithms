using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class BubbleSort2
    {
        public static void Sort<T>(IList<T> list) where T: IComparable
        {
            bool swap = true;
            while (swap)
            {
                swap = false;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].CompareTo(list[i - 1]) < 0)
                    {
                        T tmp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = tmp;
                        swap = true;
                    }
                }
            }
        }
    }
}
