using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Collections.Generic;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class ArrayAlgorithmsTests
    {
        [TestMethod]
        public void TestMergeTwoSortedArrays()
        {
            int[] arr1 = {1, 3, 5};
            int[] arr2 = { 2, 4 };
            int[] res = ArrayAlgorithms.MergeTwoSortedArrays(arr1, arr2);
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(2, res[1]);
            Assert.AreEqual(3, res[2]);
            Assert.AreEqual(4, res[3]);
            Assert.AreEqual(5, res[4]);
        }

        [TestMethod]
        public void ArrayOfArraysTest()
        {
            int[,] arr = new int[2,2];
            arr[0, 0] = 1;
            arr[1, 0] = 2;
            arr[0, 1] = 3;
            arr[1, 1] = 4;

            for (int i = 0; i < arr.GetLength(1); i++)
                for (int j = 0; j < arr.GetLength(0); j++)
                    Console.WriteLine(arr[i, j].ToString() + " ");

        }

        [TestMethod]
        public void TestGetWordOcurrences()
        {
            char[,] arr = new char[,] 
            {
                { 'w', 'a', 'k', 'o'},
                { 's', 'a', 'c', 'h'}, 
                { 'r', 'c', 'h', 'i'}, 
                { 't', 'h', 'u', 'n'}, 
                { 'g', 'i', 'j', 'y'}, 
                { 'g', 'n', 'j', 'q'}
            };

            Assert.AreEqual(4, ArrayAlgorithms.GetWordOcurrences(arr, "sachin"));
        }

        [TestMethod]
        public void TestFindSubSetWhichSumIsZero()
        {
            List<int> l = new List<int>() { 1, 2, 3 };

            SumEqualsZeroResult r = new SumEqualsZeroResult();            

            l.Permute(r.IsValidSolutionForZeroSum);

            Assert.AreEqual(-1, r.Result[0]);
            Assert.AreEqual(-2, r.Result[1]);
            Assert.AreEqual(3, r.Result[2]);
        }

        [TestMethod]
        public void TestFindSubSetWhichSumIsZero2()
        {
            List<int> l = new List<int>() { 10, 5, 20, 3, 2};

            SumEqualsZeroResult r = new SumEqualsZeroResult();

            l.Permute(r.IsValidSolutionForZeroSum);

            Assert.AreEqual(-20, r.Result[0]);            
        }
    }
}
