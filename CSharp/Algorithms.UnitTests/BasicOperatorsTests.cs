using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class BasicOperatorsTests
    {
        [TestMethod]
        public void TestModAndFloats()
        {

            Assert.AreEqual(0, 10.5F % 10.5F);
            Assert.AreEqual(0.5F, 10.5F % 10F);
            Assert.AreEqual(0, 200F % 10F);
        }
    }
}
