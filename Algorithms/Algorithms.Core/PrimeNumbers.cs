using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class PrimeNumbers
    {
        /// <summary>
        /// Generate prime numbers by brute force. O(n^2)
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IList<int> GeneratePrimeNumbers1(int limit)
        {
            if (limit < 2)
                throw new ArgumentOutOfRangeException("Limit must be > 1");

            List<int> result =  new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                bool prime = true;
                for (int j = 2; j <= i - 1; j++)
                {
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                    result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// Generate Prime Numbers, using previously computed  primes. Maybe O(n log n)?
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IList<int> GeneratePrimeNumbers2(int limit)
        {
            if (limit < 2)
                throw new ArgumentOutOfRangeException("Limit must be > 1");

            List<int> result = new List<int>();
            result.Add(2);
            for (int i = 3; i <= limit; i++)
            {
                bool prime = true;
                foreach (int j in result)
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }
                if (prime)
                    result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// Using sqrt and  only odd numbers  to minimize  the quantity of tests. Improves performance. What is the complexity? Maybe  O((n log n) / 2)?
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IList<int> GeneratePrimeNumbers3(int limit)
        {
            if (limit < 2)
                throw new ArgumentOutOfRangeException("Limit must be > 2");

            List<int> result = new List<int>();
            result.Add(2);

            List<int> potentialPrimes = new List<int>();
            int potentialPrime = 3;
            while (potentialPrime <= limit)
            {                
                bool isPrime = true;
                foreach(int j in result)
                {
                    if (j > Math.Sqrt(potentialPrime))
                        break;
                    if (potentialPrime % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    result.Add(potentialPrime);
                potentialPrime += 2;
            }
            return result;
        }
    }
}
