using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Core;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void TestQuickSort()
        {
            List<int> l = new List<int>();
            l.Add(50);
            l.Add(20);
            l.Add(10);
            l.Add(600);
            l.Add(30);

            QuickSort.Sort(l);
            Assert.AreEqual(10, l[0]);
            Assert.AreEqual(20, l[1]);
            Assert.AreEqual(30, l[2]);
            Assert.AreEqual(50, l[3]);
            Assert.AreEqual(600, l[4]);
        }

        [TestMethod]
        public void TestQuickSort2()
        {
            List<int> l = new List<int>();
            l.Add(2);
            l.Add(5);
            l.Add(4);
            l.Add(3);
            l.Add(10);

            QuickSort.Sort(l);
            Assert.AreEqual(2, l[0]);
            Assert.AreEqual(3, l[1]);
            Assert.AreEqual(4, l[2]);
            Assert.AreEqual(5, l[3]);
            Assert.AreEqual(10, l[4]);
        }

        [TestMethod]
        public void TestQuickSort3()
        {
            List<int> l = new List<int>();
            l.Add(20);
            l.Add(5);
            l.Add(10);            

            QuickSort.Sort(l);
            Assert.AreEqual(5, l[0]);
            Assert.AreEqual(10, l[1]);
            Assert.AreEqual(20, l[2]);            
        }

        [TestMethod]
        public void TestQuickSort4()
        {
            List<int> l = new List<int>();
            l.Add(20);
            l.Add(15);
            l.Add(5);
            l.Add(10);

            QuickSort.Sort(l);
            Assert.AreEqual(5, l[0]);
            Assert.AreEqual(10, l[1]);
            Assert.AreEqual(15, l[2]);
            Assert.AreEqual(20, l[3]);
        }


        [TestMethod]
        public void TestQuickSort5()
        {
            List<int> l = new List<int>();
            l.Add(5);
            l.Add(15);
            l.Add(6);
            l.Add(16);
            l.Add(10);

            QuickSort.Sort(l);
            Assert.AreEqual(5, l[0]);
            Assert.AreEqual(6, l[1]);
            Assert.AreEqual(10, l[2]);
            Assert.AreEqual(15, l[3]);
            Assert.AreEqual(16, l[4]);
        }

        [TestMethod]
        public void TestQuickSort6()
        {
            List<int> l = new List<int>() { 9, 4, 5, 3, 15, 2 };            

            QuickSort.Sort(l);            
        }
    }
}
