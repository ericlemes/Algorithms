using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public static class SquareRoot
    {
        /// <summary>
        /// O(log n)
        /// </summary>
        /// <param name="r"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static decimal Calc(decimal r, int precision)
        {
            if (r < 1)
                throw new ArgumentOutOfRangeException("Must be greater than 1");

            decimal low = 1;
            decimal high = r;
            decimal mid = (low + high) / 2;
            decimal pow = Math.Round(mid * mid, precision);
            while (pow != r)
            {
                if (pow > r)                
                    high = mid;                                    
                else                
                    low = mid;                                                 
                mid = Math.Round((low + high) / 2, precision);
                pow = Math.Round(mid * mid, precision);
            }
            return mid;
        }
    }
}
