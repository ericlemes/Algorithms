using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class Random
    {

        public static List<int> GetFirstRandomElements<T>(List<bool> alreadyPicked, List<T> inputList, int pickCount)
        {
            if (alreadyPicked.Count < inputList.Count)
                throw new ArgumentException("alreadPickedList must be the same size or bigger than inputList");

            System.Random random = new System.Random();            

            List<int> result = new List<int>(pickCount);
            while (result.Count < pickCount)
            {
                bool used = true;
                int position = -1;
                while (used)
                {
                    position = random.Next(0, inputList.Count);
                    if (!alreadyPicked[position])
                    {
                        used = false;
                        alreadyPicked[position] = true;
                    }                    
                }
                result.Add(position);
            }
            return result;
        }
    }
}
