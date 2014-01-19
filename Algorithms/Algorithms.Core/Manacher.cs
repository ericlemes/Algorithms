using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class Manacher
    {
        private static string PreProcess(string str)
        {
            int len = str.Length;
            if (len == 0)
                return "^$";
            String s = "^";
            for (int i = 0; i < len; i++)
                s += "#" + str[i];
            s += "#$";
            return s;
        }
        

        public  static string GetLongestPalindrome(String str)
        {
            /** preprocess string **/
            char[] s = PreProcess(str).ToCharArray();
            int N = s.Length;
            int[] p = new int[N + 1];
            int id = 0;
            int mx = 0;
            for (int i = 1; i < N - 1; i++)
            {
                p[i] = mx > i ? Math.Min(p[2 * id - i], mx - i) : 0;
                while (s[i + 1 + p[i]] == s[i - 1 - p[i]])
                    p[i]++;
                if (i + p[i] > mx)
                {
                    mx = i + p[i];
                    id = i;
                }
            }
            /** length of largest palindrome **/
            int maxLen = 0;
            /** position of center of largest palindrome **/
            int centerIndex = 0;
            for (int i = 1; i < N - 1; i++)
            {
                if (p[i] > maxLen)
                {
                    maxLen = p[i];
                    centerIndex = i;
                }
            }
            /** starting index of palindrome **/
            int pos = (centerIndex - 1 - maxLen) / 2;
            return str.Substring(pos, (pos) + maxLen);
        }
    }
}
