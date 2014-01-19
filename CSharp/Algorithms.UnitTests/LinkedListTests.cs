using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestAddFirstItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Test");
            Assert.AreEqual(1, l.Count);
            Assert.AreEqual("Test", l.First.Item);
        }

        [TestMethod]
        public void TestAddMoreItemsBegin()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 1");
            l.AddBegin("Item 2");
            l.AddBegin("Item 3");
            Assert.AreEqual("Item 3", l.First.Item);
            Assert.AreEqual("Item 2", l.First.Next.Item);
            Assert.AreEqual("Item 1", l.First.Next.Next.Item);
            Assert.IsNull(l.First.Next.Next.Next);
        }

        [TestMethod]
        public void TestAddMoreItemsEnd()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddEnd("Item 1");
            l.AddEnd("Item 2");
            l.AddEnd("Item 3");
            Assert.AreEqual("Item 1", l.First.Item);
            Assert.AreEqual("Item 2", l.First.Next.Item);
            Assert.AreEqual("Item 3", l.First.Next.Next.Item);
            Assert.IsNull(l.First.Next.Next.Next);
        }

        [TestMethod]
        public void TestGetLastItemWithEmptyList()
        {
            LinkedList<string> l = new LinkedList<string>();
            Assert.IsNull(l.GetLastItem());
        }

        [TestMethod]
        public void TestGetLastItemWithSingleItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Test1");
            Assert.AreEqual("Test1", l.GetLastItem().Item);
        }

        [TestMethod]
        public void TestGetLastItemWithTwoItems()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Test2");
            l.AddBegin("Test1");
            Assert.AreEqual("Test2", l.GetLastItem().Item);
        }

        [TestMethod]
        public void TestSearchItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");
            Assert.AreEqual("Item 2", l.Find("Item 2").Item);
        }

        [TestMethod]
        public void TestSearchLastItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");
            Assert.AreEqual("Item 3", l.Find("Item 3").Item);
        }

        [TestMethod]
        public void TestDeleteFirstItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");
            LinkedListItem<string> i = l.Find("Item 1");
            l.Delete(i);

            Assert.AreEqual("Item 2", l.First.Item);
            Assert.AreEqual("Item 3", l.First.Next.Item);
            Assert.IsNull(l.First.Next.Next);
        }

        [TestMethod]
        public void TestDeleteSecondItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");
            
            LinkedListItem<string> i = l.Find("Item 2");
            l.Delete(i);

            Assert.AreEqual("Item 1", l.First.Item);
            Assert.AreEqual("Item 3", l.First.Next.Item);
            Assert.IsNull(l.First.Next.Next);
        }

        [TestMethod]
        public void TestDeleteLastItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");

            LinkedListItem<string> i = l.Find("Item 3");
            l.Delete(i);

            Assert.AreEqual("Item 1", l.First.Item);
            Assert.AreEqual("Item 2", l.First.Next.Item);
            Assert.IsNull(l.First.Next.Next);
        }

        [TestMethod]
        public void TestDetectLoop()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 4");
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");

            Assert.IsFalse(l.IsInLoop());

            l.Find("Item 4").SetNext(l.Find("Item 2"));

            Assert.IsTrue(l.IsInLoop());
        }

        [TestMethod]
        public void TestDetectLoop2()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 4");
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");

            Assert.IsFalse(l.IsInLoop2());

            l.Find("Item 4").SetNext(l.Find("Item 2"));

            Assert.IsTrue(l.IsInLoop2());
        }

        [TestMethod]
        public void TestReverse1()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 4");
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");

            l.Reverse1();
            Assert.AreEqual("Item 4", l.First.Item);
            Assert.AreEqual("Item 3", l.First.Next.Item);
            Assert.AreEqual("Item 2", l.First.Next.Next.Item);
            Assert.AreEqual("Item 1", l.First.Next.Next.Next.Item);
        }

        [TestMethod]
        public void TestReverse1WithSingleItem()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 4");            

            l.Reverse1();
            Assert.AreEqual("Item 4", l.First.Item);            
        }

        [TestMethod]
        public void TestReverse1WithTwoElements()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 4");
            l.AddBegin("Item 3");

            l.Reverse1();
            
            Assert.AreEqual("Item 4", l.First.Item);
            Assert.AreEqual("Item 3", l.First.Next.Item);
        }

        [TestMethod]
        public void TestReverse2()
        {
            LinkedList<string> l = new LinkedList<string>();
            l.AddBegin("Item 4");
            l.AddBegin("Item 3");
            l.AddBegin("Item 2");
            l.AddBegin("Item 1");

            l.Reverse2();
            Assert.AreEqual("Item 4", l.First.Item);
            Assert.AreEqual("Item 3", l.First.Next.Item);
            Assert.AreEqual("Item 2", l.First.Next.Next.Item);
            Assert.AreEqual("Item 1", l.First.Next.Next.Next.Item);
        }

        [TestMethod]

        public void TestMergeTwoSortedLinkedLists()
        {
            LinkedList<int> l1 = new LinkedList<int>();
            l1.AddBegin(5);
            l1.AddBegin(3);
            l1.AddBegin(1);

            LinkedList<int> l2 = new LinkedList<int>();
            l2.AddBegin(4);
            l2.AddBegin(2);

            LinkedListItem<int> res = LinkedList<int>.MergeTwoSortedLists(l1.First, l2.First);
            Assert.AreEqual(1, res.Item);
            Assert.AreEqual(2, res.Next.Item);
            Assert.AreEqual(3, res.Next.Next.Item);
            Assert.AreEqual(4, res.Next.Next.Next.Item);
            Assert.AreEqual(5, res.Next.Next.Next.Next.Item);
            Assert.IsNull(res.Next.Next.Next.Next.Next);
        }

    }
}
