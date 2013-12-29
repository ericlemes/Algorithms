using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class QuickSort
    {
        public static void Sort<T>(IList<T> l) where T: IComparable
        {
            Sort(l, 0, l.Count - 1);
        }

        private static void Sort<T>(IList<T> l, int low, int high) where T : IComparable
        {
            if (high - low > 0)
            {
                int partition = Partition(l, low, high);
                Sort(l, low, partition - 1);
                Sort(l, partition + 1, high);
            }
        }

        private static int Partition<T>(IList<T> l, int low, int high) where T : IComparable
        {
            int pivot = high;
            int firstHigh = low;
            for (int i = low; i < high; i++)
            {
                if (l[i].CompareTo(l[pivot]) < 0)
                {
                    l.Swap(i, firstHigh);
                    firstHigh++;
                }
            }
            l.Swap(pivot, firstHigh);
            return firstHigh;
        }

 
    }
}
