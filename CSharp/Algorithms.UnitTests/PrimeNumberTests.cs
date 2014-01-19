using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Algorithms.Core;
using System.Diagnostics;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class PrimeNumberTests
    {
        private int[] primes = new int[25] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        [TestMethod]
        public void TestGenerate100PrimeNumbers()
        {
            var result = PrimeNumbers.GeneratePrimeNumbers1(100);
            Assert.IsTrue(Enumerable.SequenceEqual(primes, result));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbersWithNegativeArgument()
        {
            PrimeNumbers.GeneratePrimeNumbers1(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbersWithZeroArgument()
        {
            PrimeNumbers.GeneratePrimeNumbers1(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbersWithArgumentEquals1()
        {
            PrimeNumbers.GeneratePrimeNumbers1(1);
        }

        [TestMethod]
        public void TestGenerate100PrimeNumbers2()
        {
            var result = PrimeNumbers.GeneratePrimeNumbers2(100);
            Assert.IsTrue(Enumerable.SequenceEqual(primes, result));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbers2WithNegativeArgument()
        {
            PrimeNumbers.GeneratePrimeNumbers2(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbers2WithZeroArgument()
        {
            PrimeNumbers.GeneratePrimeNumbers2(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbers2WithArgumentEquals1()
        {
            PrimeNumbers.GeneratePrimeNumbers2(1);
        }

        [TestMethod]
        public void ComparePrimeMethods()
        {
            var result1 = PrimeNumbers.GeneratePrimeNumbers1(100000);
            var result2 = PrimeNumbers.GeneratePrimeNumbers2(100000);
            var result3 = PrimeNumbers.GeneratePrimeNumbers3(100000);
            Assert.IsTrue(Enumerable.SequenceEqual(result1, result2));
            Assert.IsTrue(Enumerable.SequenceEqual(result1, result3));
        }

        [TestMethod]
        public void ComputeTimesPrimes()
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            PrimeNumbers.GeneratePrimeNumbers1(100000);
            Console.WriteLine("Primes 1: " + w.ElapsedMilliseconds.ToString());
            w.Stop();
            w.Reset();
            w.Start();
            PrimeNumbers.GeneratePrimeNumbers2(100000);
            Console.WriteLine("Primes 2: "+ w.ElapsedMilliseconds.ToString());
            w.Stop();
            w.Reset();
            w.Start();
            PrimeNumbers.GeneratePrimeNumbers3(100000);
            Console.WriteLine("Primes 3: " + w.ElapsedMilliseconds.ToString());
            w.Stop();
            w.Start();
            for (int i = 1; i <= 100000; i++)
            {
                int mod = i % 2;
            }
            w.Stop();
            Console.WriteLine("Primes 4: " + w.ElapsedMilliseconds.ToString());
        }

        [TestMethod]
        public void TestGenerate100PrimeNumbers3()
        {
            var result = PrimeNumbers.GeneratePrimeNumbers3(100);
            Assert.IsTrue(Enumerable.SequenceEqual(primes, result));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbers3WithNegativeArgument()
        {
            PrimeNumbers.GeneratePrimeNumbers3(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbers3WithZeroArgument()
        {
            PrimeNumbers.GeneratePrimeNumbers3(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGeneratePrimeNumbers3WithArgumentEquals1()
        {
            PrimeNumbers.GeneratePrimeNumbers3(1);
        }
    }
}
