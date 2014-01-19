using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class UnbalancedBinaryTreeTests
    {
        [TestMethod]
        public void TestInsert()
        {
            UnbalancedBinaryTree<string> tree = new UnbalancedBinaryTree<string>();
            tree.Insert("Test 3");
            tree.Insert("Test 2");
            tree.Insert("Test 1");
            tree.Insert("Test 5");
            tree.Insert("Test 4");

            Assert.AreEqual("Test 3", tree.Root.Item);
            Assert.AreEqual("Test 2", tree.Root.Left.Item);
            Assert.AreEqual("Test 3", tree.Root.Left.Parent.Item);
            Assert.AreEqual("Test 1", tree.Root.Left.Left.Item);
            Assert.AreEqual("Test 2", tree.Root.Left.Left.Parent.Item);
            Assert.AreEqual("Test 5", tree.Root.Right.Item);
            Assert.AreEqual("Test 3", tree.Root.Right.Parent.Item);
            Assert.AreEqual("Test 4", tree.Root.Right.Left.Item);
            Assert.AreEqual("Test 5", tree.Root.Right.Left.Parent.Item);
        }

        [TestMethod]
        public void TestSearch()
        {
            UnbalancedBinaryTree<string> tree = new UnbalancedBinaryTree<string>();
            tree.Insert("Test 3");
            tree.Insert("Test 2");
            tree.Insert("Test 1");
            tree.Insert("Test 5");
            tree.Insert("Test 4");

            Assert.AreEqual("Test 5", tree.Search("Test 5").Item);
            Assert.IsNull(tree.Search("Test 6"));
        }

        [TestMethod]
        public void TestMinimumAndMaximum()
        {
            UnbalancedBinaryTree<string> tree = new UnbalancedBinaryTree<string>();
            tree.Insert("Test 3");
            tree.Insert("Test 2");
            tree.Insert("Test 1");
            tree.Insert("Test 5");
            tree.Insert("Test 4");

            Assert.AreEqual("Test 1", tree.GetMinimum().Item);
            Assert.AreEqual("Test 5", tree.GetMaximum().Item);
        }

        [TestMethod]
        public void TestTraverse()
        {
            UnbalancedBinaryTree<string> tree = new UnbalancedBinaryTree<string>();
            tree.Insert("Test 3");
            tree.Insert("Test 2");
            tree.Insert("Test 1");
            tree.Insert("Test 5");
            tree.Insert("Test 4");

            var traverseResult = tree.TraverseSorted();
            Assert.AreEqual("Test 1", traverseResult[0].Item);
            Assert.AreEqual("Test 2", traverseResult[1].Item);
            Assert.AreEqual("Test 3", traverseResult[2].Item);
            Assert.AreEqual("Test 4", traverseResult[3].Item);
            Assert.AreEqual("Test 5", traverseResult[4].Item);
        }

        [TestMethod]
        public void TestDeleteNodeWithNoChildren()
        {
            UnbalancedBinaryTree<int> tree = new UnbalancedBinaryTree<int>();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(5);

            tree.Delete(tree.Search(3));
            Assert.AreEqual(2, tree.Root.Item);
            Assert.AreEqual(1, tree.Root.Left.Item);
            Assert.AreEqual(7, tree.Root.Right.Item);
            Assert.AreEqual(4, tree.Root.Right.Left.Item);
            Assert.AreEqual(8, tree.Root.Right.Right.Item);
            Assert.AreEqual(6, tree.Root.Right.Left.Right.Item);
            Assert.AreEqual(5, tree.Root.Right.Left.Right.Left.Item);
        }

        [TestMethod]
        public void TestDeleteNodeWithOneChild()
        {
            UnbalancedBinaryTree<int> tree = new UnbalancedBinaryTree<int>();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(5);

            tree.Delete(tree.Search(6));
            Assert.AreEqual(2, tree.Root.Item);
            Assert.AreEqual(1, tree.Root.Left.Item);
            Assert.AreEqual(7, tree.Root.Right.Item);
            Assert.AreEqual(4, tree.Root.Right.Left.Item);
            Assert.AreEqual(8, tree.Root.Right.Right.Item);
            Assert.AreEqual(3, tree.Root.Right.Left.Left.Item);
            Assert.AreEqual(5, tree.Root.Right.Left.Right.Item);
        }

        [TestMethod]
        public void TestDeleteNodeWithTwoChildren()
        {
            UnbalancedBinaryTree<int> tree = new UnbalancedBinaryTree<int>();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(5);

            tree.Delete(tree.Search(4));
            Assert.AreEqual(2, tree.Root.Item);
            Assert.AreEqual(1, tree.Root.Left.Item);
            Assert.AreEqual(7, tree.Root.Right.Item);
            Assert.AreEqual(5, tree.Root.Right.Left.Item);
            Assert.AreEqual(8, tree.Root.Right.Right.Item);
            Assert.AreEqual(3, tree.Root.Right.Left.Left.Item);
            Assert.AreEqual(6, tree.Root.Right.Left.Right.Item);
        }

        [TestMethod]
        public void TestDetectMirror()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();            
            t.Root = new UnbalancedBinaryTreeItem<int>(1);
            t.Root.CreateLeft(2);
            t.Root.CreateRight(2);
            t.Root.Left.CreateLeft(3);
            t.Root.Left.CreateRight(4);
            t.Root.Right.CreateLeft(4);
            t.Root.Right.CreateRight(3);
            t.Root.Left.Left.CreateLeft(5);
            t.Root.Right.Right.CreateRight(5);

            Assert.IsTrue(t.IsMirror());
        }

        [TestMethod]
        public void TestDetectMirror2()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Root = new UnbalancedBinaryTreeItem<int>(1);
            t.Root.CreateLeft(2);
            t.Root.CreateRight(2);
            t.Root.Left.CreateLeft(3);
            t.Root.Left.CreateRight(4);
            t.Root.Right.CreateLeft(4);
            t.Root.Right.CreateRight(3);
            t.Root.Left.Left.CreateLeft(5);            

            Assert.IsFalse(t.IsMirror());
        }

        [TestMethod]
        public void TestTraverseBinaryTreeByLevel()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(5);
            t.Insert(4);
            t.Insert(10);
            t.Insert(7);
            t.Insert(1);
            t.Insert(3);

            List<UnbalancedBinaryTreeItem<int>> l = t.TraverseByLevel();
            Assert.AreEqual(5, l[0].Item);
            Assert.IsNull(l[1]); // Level change
            Assert.AreEqual(4, l[2].Item);
            Assert.AreEqual(10, l[3].Item);
            Assert.IsNull(l[4]); // Level change
            Assert.AreEqual(1, l[5].Item);
            Assert.AreEqual(7, l[6].Item);
            Assert.IsNull(l[7]); // Level change
            Assert.AreEqual(3, l[8].Item);

        }

        [TestMethod]
        public void CreateBalancedBinaryTreeBasedOnTwoUnbalacedBinaryTreesTest()
        {
            UnbalancedBinaryTree<int> tree1 = new UnbalancedBinaryTree<int>();
            tree1.Insert(5);
            tree1.Insert(3);
            tree1.Insert(2);
            tree1.Insert(1);
            tree1.Insert(9);
            tree1.Insert(12);
            tree1.Insert(11);

            UnbalancedBinaryTree<int> tree2 = new UnbalancedBinaryTree<int>();
            tree2.Insert(15);
            tree2.Insert(14);
            tree2.Insert(10);
            tree2.Insert(20);
            tree2.Insert(19);
            tree2.Insert(25);            

            IList<int> traverseResult1 = tree1.TraverseSortedAsList();
            IList<int> traverseResult2 = tree2.TraverseSortedAsList();
            var merged = traverseResult1.Merge(traverseResult2);

            UnbalancedBinaryTree<int> mergedBalanced = new UnbalancedBinaryTree<int>();
            mergedBalanced.InsertSortedList(merged);
        }

        [TestMethod]
        public void TestValidateBinaryTreeForInvalidTree()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Root = new UnbalancedBinaryTreeItem<int>(1);
            t.Root.CreateLeft(2);
            t.Root.CreateRight(2);
            t.Root.Left.CreateLeft(3);
            t.Root.Left.CreateRight(4);
            t.Root.Right.CreateLeft(4);
            t.Root.Right.CreateRight(3);
            t.Root.Left.Left.CreateLeft(5);
            t.Root.Right.Right.CreateRight(5);

            Assert.IsFalse(t.IsValid());
        }

        [TestMethod]
        public void TestValidateBinaryTreeForValidTree()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(5);
            t.Insert(3);
            t.Insert(8);
            t.Insert(1);
            t.Insert(4);
            t.Insert(9);

            Assert.IsTrue(t.IsValid());
        }

        [TestMethod]
        public void TestIsBalanced()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(1);
            t.Insert(2);
            t.Insert(3);

            Assert.IsFalse(t.IsBalanced());
        }

        [TestMethod]
        public void TestIsBalanced2()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(4);
            t.Insert(2);
            t.Insert(3);
            t.Insert(1);
            t.Insert(6);
            t.Insert(5);
            t.Insert(7);

            Assert.IsTrue(t.IsBalanced());
            Assert.AreEqual(3, t.GetHeight());
        }

        [TestMethod]
        public void TestGetHeight()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(1);
            t.Insert(2);
            t.Insert(3);

            Assert.AreEqual(3, t.GetHeight());                
        }

        [TestMethod]
        public void TestCommonAncestor()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(4);
            t.Insert(2);
            t.Insert(3);
            t.Insert(1);
            t.Insert(6);
            t.Insert(5);
            t.Insert(7);

            Assert.AreEqual(4, t.FindCommonAncestor(t.Search(3), t.Search(5)).Item);
            Assert.AreEqual(4, t.FindCommonAncestor(t.Search(3), t.Search(6)).Item);
        }

        [TestMethod]
        public void TestConvertBinaryTreeToDoubleLinkedList()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(4);
            t.Insert(2);
            t.Insert(3);
            t.Insert(1);
            t.Insert(6);
            t.Insert(5);
            t.Insert(7);

            UnbalancedBinaryTreeItem<int> dll = t.ConvertBinaryTreeToDoubleLinkedList(t.Root);
            while (dll.Left != null)
                dll = dll.Left;

            Assert.AreEqual(1, dll.Item);
            Assert.AreEqual(2, dll.Right.Item);
            Assert.AreEqual(3, dll.Right.Right.Item);
            Assert.AreEqual(4, dll.Right.Right.Right.Item);
            Assert.AreEqual(5, dll.Right.Right.Right.Right.Item);
            Assert.AreEqual(6, dll.Right.Right.Right.Right.Right.Item);
            Assert.AreEqual(7, dll.Right.Right.Right.Right.Right.Right.Item);
            Assert.IsNull(dll.Right.Right.Right.Right.Right.Right.Right);
        }

        [TestMethod]
        public void TestTraverseByLevel()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(4);
            t.Insert(2);
            t.Insert(3);
            t.Insert(1);
            t.Insert(6);
            t.Insert(5);
            t.Insert(7);

            t.LevelOrderTraversal((i) => { Console.Write(i.Item.ToString() + " "); });
        }

        [TestMethod]
        public void TestTraverseByLevelZigZag()
        {
            UnbalancedBinaryTree<int> t = new UnbalancedBinaryTree<int>();
            t.Insert(4);
            t.Insert(2);
            t.Insert(3);
            t.Insert(1);
            t.Insert(6);
            t.Insert(5);
            t.Insert(7);

            t.LevelOrderTraversalZigZag((i) => { Console.Write(i.Item.ToString() + " "); });
        }
    }
}
