using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static  class Fibonacci
    {
        public const double GoldenRatio = 1.6180339F;

        /// <summary>
        /// Calculate Nth number of Fibonacci sequence in O(2 ^ n). 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static int GetNthFibonacciSequenceNumberRecursive(int position)
        {
            if (position <= 0)
                throw new Exception("Position must be > 0");
            if (position == 1)
                return 0;
            else if (position == 2)
                return 1;
            else
                return GetNthFibonacciSequenceNumberRecursive(position - 1) + GetNthFibonacciSequenceNumberRecursive(position - 2);
        }

        /// <summary>
        /// Generate  the  Nth element in  Fibonacci sequence. O(n), with f(n) = n. More efficient than recursive one.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Int64 GetNthFibonacciSequenceNumberIteratively(int position)
        {
            if (position <= 0)
                throw new Exception("Position must be > 0");
            if (position == 1)
                return 0;
            else if (position == 2)
                return 1;
            else
            {
                int result = 0, p1 = 0, p2 = 1;
                for (int i = 3; i <= position; i++)
                {
                    result = p1 + p2;
                    p1 = p2;
                    p2 = result;                   
                }
                return result;
            }
        }

        /// <summary>
        /// Generate the Nth Fibonacci  sequence  number using Binet's formula. Could affirm that it is O(1), but not sure about Sqrt and Pow implementations.
        /// Innacurate. Return wrong results after 40 position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Int64 GetNthFibonacciSequenceNumberBinet(int position)
        {
            if (position <= 0)
                throw new Exception("Position must be > 0");
            if (position == 1)
                return 0;
            else if (position == 2)
                return 1;
            else
            {
                double d = Math.Round(Math.Pow(GoldenRatio, position - 1) / Math.Sqrt(5));                
                return Convert.ToInt64(d);
            }
        }
    }
}
