using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Core;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class RandomTests
    {
        [TestMethod]
        public void GetRandomElementsFromListTest()
        {
            List<int> l = new List<int>(10);
            for (int i = 0; i < 10; i++)
                l.Add(i);                

            List<bool> alreadyPicked = new List<bool>(l.Count);
            for (int i = 0; i < 10; i++)
                alreadyPicked.Add(false);

            List<int> res1 = Algorithms.Core.Random.GetFirstRandomElements(alreadyPicked, l, 3);
            List<int> res2 = Algorithms.Core.Random.GetFirstRandomElements(alreadyPicked, l, 7);

            Assert.AreEqual(3, res1.Count);
            Assert.AreEqual(7, res2.Count);
        }

        [TestMethod]
        public void GetRandomElementsFromListShufflingTest()
        {
            List<int> l = new List<int>(10);
            for (int i = 0; i < 10; i++)
                l.Add(i);

            l.Shuffle();
        }
    }
}
