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

        public static IList<T> Merge<T>(this IList<T> list1, IList<T> list2) where T : IComparable
        {
            int l1Index = 0;
            int l2index = 0;

            List<T> result = new List<T>();
            bool hasPending = l1Index < (list1.Count - 1) && l2index < (list2.Count - 1);
            while (hasPending)
            {
                if (l1Index <= (list1.Count - 1) && l2index <= (list2.Count - 1))
                {
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

        public static void Shuffle<T>(this IList<T> l)
        {
            System.Random random = new System.Random();
            for (int i = 0; i < l.Count; i++)
            {
                int first = random.Next(0, l.Count);
                int second = random.Next(0, l.Count);
                l.Swap(first, second);
            }
        }

        public static void Permute<T>(this IList<T> l, ValidatePermutationDelegate<T> validatePermutationCallback)
        {
            ValidatePermutationCallbackResult r = PermuteRecur(l, validatePermutationCallback, 0);
        }

        private static ValidatePermutationCallbackResult PermuteRecur<T>(this IList<T> l, ValidatePermutationDelegate<T> validatePermutationCallback,
            int index)
        {
            if (index > l.Count - 1)
                return new ValidatePermutationCallbackResult { ContinuePermutatingThisSubset = true, IsOptimalSolution = false };

            if (validatePermutationCallback != null)
            {
                ValidatePermutationCallbackResult result = validatePermutationCallback(l, index, index < l.Count - 1);
                if (result.IsOptimalSolution || !result.ContinuePermutatingThisSubset)
                    return result;
            }

            for (int i = index + 1; i < l.Count; i++)
            {
                l.Swap(index, i);
                ValidatePermutationCallbackResult r = PermuteRecur(l, validatePermutationCallback, i + 1);
                l.Swap(index, i);
                if (r.IsOptimalSolution)
                    return r;
            }

            return new ValidatePermutationCallbackResult { ContinuePermutatingThisSubset = true, IsOptimalSolution = false };
        }

        public static HashSet<List<T>> PowerSet<T>(this IList<T> originalList)
        {
            HashSet<List<T>> sets = new HashSet<List<T>>();
            if (originalList.Count <= 0)
            {
                sets.Add(new List<T>());
                return sets;
            }

            List<T> list = new List<T>(originalList);
            T first = list[0];
            IList<T> remaining = list.GetSubList(1, list.Count - 1);

            foreach (IList<T> l in PowerSet(remaining))
            {
                List<T> newList = new List<T>();
                newList.Add(first);
                newList.AddRange(l);
                sets.Add(newList);
                sets.Add((List<T>)l);
            }
            return sets;


        }

        public static IList<T> GetSubList<T>(this List<T> l, int low, int high)
        {
            List<T> sublist = new List<T>();
            for (int i = low; i <= high; i++)
                sublist.Add(l[i]);
            return sublist;
        }
    }

    public delegate ValidatePermutationCallbackResult ValidatePermutationDelegate<T>(IList<T> list, int index, bool isPartial);

    public class ValidatePermutationCallbackResult
    {
        public bool IsOptimalSolution
        {
            get;
            set;
        }

        public bool ContinuePermutatingThisSubset
        {
            get;
            set;
        }
    }


}
