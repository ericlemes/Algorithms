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

        public static string ReverseWordsInSentence(this string sentence)
        {
            int high = -1;
            int low = -1;
            string result = null;
            for (int i = sentence.Length - 1; i >= -1; i--)
            {
                if (i == -1 || sentence[i] == ' ')
                {
                    //end of word
                    if (high >= 0 && low >= 0)
                    {
                        //I have a word
                        result += sentence.Substring(low, (high - low) + 1);
                        high = -1;
                        low = -1;
                    }
                    if (i >= 0)
                        //It's not the end of the sentence, put the space you've found.
                        result += ' ';
                }
                else
                {
                    if (high == -1)
                    {
                        high = i;
                        low = i;
                    }
                    else
                        low = i;
                }
            }
            return result;
        }

        public static bool IsSubstring(this string s, string substring)
        {
            bool equal = false;
            for (int i = 0; i < s.Length; i++)
            {
                equal = true;
                if (i + substring.Length - 1 > s.Length - 1)
                {
                    equal = false;
                    break;
                }
                for (int j = 0; j < substring.Length; j++)
                {
                    if (s[j + i] != substring[j])
                    {
                        equal = false;
                        break;
                    }
                }
                if (equal)
                    break;
            }
            return equal;
        }

        public static string FindLongestEvenPalindromicString(this string input)
        {
            int low = -1; 
            int high = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length && input[i + 1] == input[i])
                {
                    int newlow = i;
                    int newhigh = i + 1;
                    while (newlow - 1 >= 0 && newhigh + 1 < input.Length && input[newlow - 1] == input[newhigh + 1])
                    {
                        newlow--;
                        newhigh++;
                    }
                    if ((newhigh - newlow) + 1 > (high - low) + 1)
                    {
                        high = newhigh;
                        low = newlow;
                    }
                }
            }
            if (low == -1)
                return "";
            else
                return input.Substring(low, high - low + 1);
        }
    }
}
