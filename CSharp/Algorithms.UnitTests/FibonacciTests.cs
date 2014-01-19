using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Diagnostics;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void TestGenerateFirstFibonnaciNumberRecursive()
        {
            Assert.AreEqual(0, Fibonacci.GetNthFibonacciSequenceNumberRecursive(1));
        }

        [TestMethod]
        public void TestGenerateSecondFibonacciNumberRecursive()
        {
            Assert.AreEqual(1, Fibonacci.GetNthFibonacciSequenceNumberRecursive(2));
        }

        [TestMethod]
        public void TestGenerate10thFibonacciNumberRecursive()
        {
            Assert.AreEqual(34, Fibonacci.GetNthFibonacciSequenceNumberRecursive(10));
        }

        [TestMethod]
        public void TestGenerate4thFibonacciNumberRecursive()        {
            Assert.AreEqual(5, Fibonacci.GetNthFibonacciSequenceNumberRecursive(6));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGenerateWithInvalidPositionRecursive()
        {
            Fibonacci.GetNthFibonacciSequenceNumberRecursive(0);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGenerateWithInvalidPosition2Recursive()
        {
            Fibonacci.GetNthFibonacciSequenceNumberRecursive(-1);
        }

        [TestMethod]
        public void TestGenerateFirstFibonnaciNumberIteratively()
        {
            Assert.AreEqual(0, Fibonacci.GetNthFibonacciSequenceNumberIteratively(1));
        }

        [TestMethod]
        public void TestGenerateSecondFibonacciNumberIteratively()
        {
            Assert.AreEqual(1, Fibonacci.GetNthFibonacciSequenceNumberIteratively(2));
        }

        [TestMethod]
        public void TestGenerate10thFibonacciNumberIteratively()
        {
            Assert.AreEqual(34, Fibonacci.GetNthFibonacciSequenceNumberIteratively(10));

        }

        [TestMethod]
        public void TestGenerate4thFibonacciNumberIteratively()
        {
            Assert.AreEqual(2, Fibonacci.GetNthFibonacciSequenceNumberIteratively(4));
        }

        [TestMethod]
        public void TestGenerate5thFibonacciNumberIteratively()
        {
            Assert.AreEqual(3, Fibonacci.GetNthFibonacciSequenceNumberIteratively(5));

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGenerateWithInvalidPositionIteratively()
        {
            Fibonacci.GetNthFibonacciSequenceNumberIteratively(0);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGenerateWithInvalidPosition2Iteratively()
        {
            Fibonacci.GetNthFibonacciSequenceNumberIteratively(-1);
        }

        [TestMethod]
        public void TestGenerateFirstFibonnaciNumberBinet()
        {
            Assert.AreEqual(0, Fibonacci.GetNthFibonacciSequenceNumberBinet(1));
        }

        [TestMethod]
        public void TestGenerateSecondFibonacciNumberBinet()
        {
            Assert.AreEqual(1, Fibonacci.GetNthFibonacciSequenceNumberBinet(2));
        }

        [TestMethod]
        public void TestGenerate10thFibonacciNumberBinet()
        {
            Assert.AreEqual(34, Fibonacci.GetNthFibonacciSequenceNumberBinet(10));

        }

        [TestMethod]
        public void TestGenerate4thFibonacciNumberBinet()
        {
            Assert.AreEqual(2, Fibonacci.GetNthFibonacciSequenceNumberBinet(4));
        }

        [TestMethod]
        public void TestGenerate5thFibonacciNumberBinet()
        {
            Assert.AreEqual(3, Fibonacci.GetNthFibonacciSequenceNumberBinet(5));
        }

        [TestMethod]
        public void ComputeTimesFibonacci()
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            Fibonacci.GetNthFibonacciSequenceNumberRecursive(40);           
            Console.WriteLine("Fibonacci recursive (40 times): " + w.ElapsedTicks.ToString());
            w.Stop();
            w.Reset();
            w.Start();
            Fibonacci.GetNthFibonacciSequenceNumberIteratively(40);
            Console.WriteLine("Fibonacci iteratively (40): " + w.ElapsedTicks.ToString());
            w.Stop();            
            w.Reset();
            w.Start();
            Fibonacci.GetNthFibonacciSequenceNumberBinet(40);
            Console.WriteLine("Fibonacci Binet (40): " + w.ElapsedTicks.ToString());
            w.Stop();            
        }
    }
}
