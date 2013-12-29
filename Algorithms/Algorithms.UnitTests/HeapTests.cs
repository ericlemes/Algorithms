using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void TestInsertHeap()
        {
            Heap<int> h = new Heap<int>();
            h.Insert(500);

            Assert.AreEqual(500, h.PeekMinimum());
            
            h.Insert(100);
            Assert.AreEqual(100, h.PeekMinimum());

            h.Insert(200);
            Assert.AreEqual(100, h.PeekMinimum());

            h.Insert(50);
            Assert.AreEqual(50, h.PeekMinimum());
        }

        [TestMethod]
        public void TestExtractMinimum()
        {
            Heap<int> h = new Heap<int>();
            h.Insert(500);          
            h.Insert(100);
            h.Insert(200);
            h.Insert(50);

            Assert.AreEqual(50, h.ExtractMinimum());
            Assert.AreEqual(100, h.ExtractMinimum());
            Assert.AreEqual(200, h.ExtractMinimum());
            Assert.AreEqual(500, h.ExtractMinimum());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExtractMinimumEmpty()
        {
            Heap<int> h = new Heap<int>();
            h.ExtractMinimum();
        }

        [TestMethod]
        public void TestGetLeft()
        {
            Assert.AreEqual(1, Heap<int>.GetLeftChild(0));
            Assert.AreEqual(3, Heap<int>.GetLeftChild(1));
            Assert.AreEqual(7, Heap<int>.GetLeftChild(3));
        }

        [TestMethod]
        public void TestHeapSort()
        {
            Heap<int> h = new Heap<int>();
            h.Insert(500);
            h.Insert(100);
            h.Insert(200);
            h.Insert(50);
            h.Insert(1);
            h.Insert(420);
            h.Insert(3);
            h.Insert(250);
            h.Insert(5);
            h.Insert(499);
            
            int[] sortedItems = h.HeapSort();
            Assert.AreEqual(1, sortedItems[0]);
            Assert.AreEqual(3, sortedItems[1]);
            Assert.AreEqual(5, sortedItems[2]);
            Assert.AreEqual(50, sortedItems[3]);
            Assert.AreEqual(100, sortedItems[4]);
            Assert.AreEqual(200, sortedItems[5]);
            Assert.AreEqual(250, sortedItems[6]);
            Assert.AreEqual(420, sortedItems[7]);
            Assert.AreEqual(499, sortedItems[8]);
            Assert.AreEqual(500, sortedItems[9]);            
        }

        [TestMethod]
        public void TestInPlaceSort()
        {
            int[] arr = new int[5];
            arr[0] = 50;
            arr[1] = 20;
            arr[2] = 10;
            arr[3] = 600;
            arr[4] = 30;

            Heap<int> h = new Heap<int>(arr);
            Assert.AreEqual(10, h.ExtractMinimum());
            Assert.AreEqual(20, h.ExtractMinimum());
            Assert.AreEqual(30, h.ExtractMinimum());
            Assert.AreEqual(50, h.ExtractMinimum());
            Assert.AreEqual(600, h.ExtractMinimum());
        }

        [TestMethod]
        public void TestInPlaceSort2()
        {
            int[] arr = new int[5];
            arr[0] = 50;
            arr[1] = 20;
            arr[2] = 10;
            arr[3] = 600;
            arr[4] = 30;

            Heap<int> h = new Heap<int>(arr);
            Assert.AreEqual(10, h.ExtractMinimum());
            Assert.AreEqual(20, h.ExtractMinimum());
            Assert.AreEqual(30, h.ExtractMinimum());
            Assert.AreEqual(50, h.ExtractMinimum());
            Assert.AreEqual(600, h.ExtractMinimum());
        }
    }
}
