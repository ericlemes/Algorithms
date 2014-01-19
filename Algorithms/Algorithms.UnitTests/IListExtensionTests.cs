using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Core;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class IListExtensionTests
    {
        [TestMethod]
        public void MergeTest()
        {
            List<int> l1 = new List<int>() {1, 3, 5};
            List<int> l2 = new List<int>() { 2, 4 };
            IList<int> merged = l1.Merge(l2);

            Assert.AreEqual(1, merged[0]);
            Assert.AreEqual(2, merged[1]);
            Assert.AreEqual(3, merged[2]);
            Assert.AreEqual(4, merged[3]);
            Assert.AreEqual(5, merged[4]);
        }

        [TestMethod]
        public void PowerSetTest()
        {
            List<int> l = new List<int>() { 1, 2, 3 };
            HashSet<List<int>> sets = l.PowerSet();
            foreach (List<int> set in sets)
            {
                foreach (int i in set)
                    Console.Write(i.ToString() + " ");
                Console.WriteLine();
            }

        }

        [TestMethod]
        public void PowerSetTest2()
        {
            List<int> l = new List<int>() { 60, 20, 10 };
            HashSet<List<int>> sets = l.PowerSet();
            foreach (List<int> set in sets)
            {
                foreach (int i in set)
                    Console.Write(i.ToString() + " ");
                Console.WriteLine();
            }

        }
    }
}
