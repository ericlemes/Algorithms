using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class CharArrayExtensions
    {
        /// <summary>
        /// Reverse in place.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static char[] Reverse(this char[] input)
        {
            int low = 0;
            int high = 0;
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] == ' ' || i == (input.Length - 1))
                {
                    if (i == input.Length - 1)
                        high = i;
                    else
                        high = i - 1;
                    Reverse(input, low, high);
                    low = i + 1;
                }
            }
            return input;
        }

        private static void Reverse(char[] input, int low, int high)
        {
            if (low < 0 || high < 0 || low >= input.Length || high >= input.Length)
                return;

            int mid = low + ((high - low) / 2);
            int strSize = ((high - low) + 1);
            bool even = (strSize % 2) == 0;

            int left = 0;            
            if (even)            
                left = mid;                            
            else            
                left = mid -1;                            
            int right = mid + 1;

            for (int i = 1; i <= strSize / 2; i++)
            {
                Swap(input, left, right);
                left--;
                right++;
            }
        }

        private static void Swap(char[] input, int i1, int i2)
        {
            char tmp = input[i1];
            input[i1] = input[i2];
            input[i2] = tmp;
        }
    }
}
