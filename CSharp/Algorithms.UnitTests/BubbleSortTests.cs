using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Collections.Generic;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void TestBubbleSort()
        {
            List<int> l = new List<int>();
            l.Add(50);
            l.Add(20);
            l.Add(10);
            l.Add(600);
            l.Add(30);                        

            BubbleSort.Sort(l);
            Assert.AreEqual(10, l[0]);
            Assert.AreEqual(20, l[1]);
            Assert.AreEqual(30, l[2]);
            Assert.AreEqual(50, l[3]);
            Assert.AreEqual(600, l[4]);
        }

        [TestMethod]
        public void TestBubbleSort2()
        {
            List<int> l = new List<int>();
            l.Add(50);
            l.Add(20);
            l.Add(10);
            l.Add(600);
            l.Add(30);

            BubbleSort2.Sort(l);
            Assert.AreEqual(10, l[0]);
            Assert.AreEqual(20, l[1]);
            Assert.AreEqual(30, l[2]);
            Assert.AreEqual(50, l[3]);
            Assert.AreEqual(600, l[4]);
        }
    }
}
