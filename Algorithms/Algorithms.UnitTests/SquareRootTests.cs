using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class SquareRootTests
    {
        [TestMethod]
        public void TestSquareRoot1()
        {
            Assert.AreEqual(4, SquareRoot.Calc(16, 0));
        }

        [TestMethod]
        public void TestSquareRoot2()
        {
            Assert.AreEqual(1.4142M, SquareRoot.Calc(2, 4));
        }
    }
}
