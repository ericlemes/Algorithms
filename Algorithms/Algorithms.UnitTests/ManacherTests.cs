using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class ManacherTests
    {
        [TestMethod]
        public void ManacherTest1()
        {
            Assert.AreEqual("baab", Manacher.GetLongestPalindrome("baab"));
            Assert.AreEqual("anana", Manacher.GetLongestPalindrome("banana"));
            Assert.AreEqual("malayalam", Manacher.GetLongestPalindrome("civicradarrevivermalayalammadamnoon"));
            
            Assert.AreEqual("aca", Manacher.GetLongestPalindrome("abracadabra"));
        }
    }
}
