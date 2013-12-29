using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class MergeSort
    {
        public static void Sort<T>(IList<T> l) where T : IComparable
        {
            Sort(l, 0, l.Count - 1);
        }

        private static void Sort<T>(IList<T> l, int low, int high) where T: IComparable
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                Sort(l, low, middle);
                Sort(l, middle + 1, high);
                Merge(l, low, middle, high);
            }
        }

        private static void Merge<T>(IList<T> l, int low, int middle, int high) where T : IComparable
        {
            Queue<T> buffer1 = new Queue<T>();
            Queue<T> buffer2 = new Queue<T>();

            for (int i = low; i <= middle; i++)
                buffer1.Enqueue(l[i]);
            for (int i = middle + 1; i <= high; i++)
                buffer2.Enqueue(l[i]);

            int j = low;
            while (buffer1.Count > 0 || buffer2.Count > 0)
            {
                if (buffer1.Count <= 0)
                    l[j++] = buffer2.Dequeue();
                else if (buffer2.Count <= 0)
                    l[j++] = buffer1.Dequeue();
                else if (buffer1.Peek().CompareTo(buffer2.Peek()) <= 0)
                    l[j++] = buffer1.Dequeue();
                else
                    l[j++] = buffer2.Dequeue();
            }
        }
    }
}
