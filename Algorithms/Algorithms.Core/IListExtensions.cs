using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class IListExtensions
    {
        public static void Swap<T>(this IList<T> l, int pos1, int pos2)
        {
            T tmp = l[pos1];
            l[pos1] = l[pos2];
            l[pos2] = tmp;
        }

        public static IList<T> Merge<T>(this IList<T> list1, IList<T> list2 ) where T: IComparable{
            int l1Index = 0;
            int l2index = 0;

            List<T> result = new List<T>();
            bool hasPending = l1Index < (list1.Count - 1) && l2index < (list2.Count - 1);
            while (hasPending)
            {
                if (l1Index <= (list1.Count - 1) && l2index <= (list2.Count - 1)){                
                    if (list1[l1Index].CompareTo(list2[l2index]) <= 0)
                    {
                        result.Add(list1[l1Index]);
                        l1Index++;
                    }
                    else
                    {
                        result.Add(list2[l2index]);
                        l2index++;
                    }
                    hasPending = l1Index <= (list1.Count - 1) || l2index <= (list2.Count - 1);
                }
                else if (l1Index <= (list1.Count - 1))
                {
                    result.Add(list1[l1Index]);
                    l1Index++;
                    hasPending = l1Index <= (list1.Count - 1);
                }
                else 
                {
                    result.Add(list2[l2index]);
                    l2index++;
                    hasPending = l2index <= (list2.Count - 1);
                }
            }

            return result;
        }
    }
}
