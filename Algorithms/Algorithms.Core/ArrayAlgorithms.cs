using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class ArrayAlgorithms
    {
        public static int[] MergeTwoSortedArrays(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length];
            int idx1 = 0, idx2 = 0, residx = 0;
            while (idx1 < arr1.Length || idx2 < arr2.Length)
            {
                if (idx1 >= arr1.Length || ((idx2 < arr2.Length) && arr2[idx2] <= arr1[idx1]))
                {
                    result[residx] = arr2[idx2];
                    idx2++;
                }
                else if (idx2 >= arr2.Length || ((idx1 < arr1.Length) && arr1[idx1] < arr2[idx2]))
                {
                    result[residx] = arr1[idx1];
                    idx1++;
                }
                residx++;
            }
            return result;
        }

        public static int GetWordOcurrences(char[,] arr, string word)
        {
            int count = 0;
            for (int y = 0; y < arr.GetLength(1); y++)
                for (int x = 0; x < arr.GetLength(0); x++)
                    GetRoutesFor(x, y, ref count, arr, arr[x, y].ToString(), word);
            return count;
        }

        private static void GetRoutesFor(int startx, int starty, ref int count, char[,] arr, string currWord, string word)
        {
            if (currWord != word.Substring(0, currWord.Length))
                return;
            if (currWord == word)
            {
                count++;
                return;
            }
            for (int y = 0; y <= 1; y++)
                for (int x = 0; x <= 1; x++)
                {
                    if (x == 0 && y == 0)
                        continue;
                    if (startx + x >= arr.GetLength(0))
                        continue;
                    if (starty + y >= arr.GetLength(1))
                        continue;
                    GetRoutesFor(startx + x, starty + y, ref count, arr, currWord + arr[startx + x, starty + y].ToString(), word);
                }
        }
    }
}
