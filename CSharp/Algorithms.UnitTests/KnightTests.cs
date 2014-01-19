using Algorithms.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class KnightTests
    {
        [TestMethod]
        public void TestRoutes()
        {
            List<KeyValuePair<int, int>> route = Knights.FindKnightRoute(new KeyValuePair<int, int>(8, 8), new KeyValuePair<int, int>(3, 3), new KeyValuePair<int, int>(7, 7));
            foreach (KeyValuePair<int, int> pair in route)
                Console.WriteLine(pair.Key.ToString() + " " + pair.Value.ToString());
        }

        [TestMethod]
        public void BitShift()
        {
            Assert.AreEqual(4, 1 << 2);
        }
    }
}
