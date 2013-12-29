using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Text;
using System.Collections.Generic;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestReverseWordsInString()
        {            
            Assert.AreEqual("cba dcba 4321", new String("abc abcd 1234".ToCharArray().Reverse()));
        }

        [TestMethod]
        public void TestReverseWordsInString2()
        {
            Assert.AreEqual("verybigword otherword plusone 1", new String("drowgibyrev drowrehto enosulp 1".ToCharArray().Reverse()));
        }

        [TestMethod]
        public void TestStringCombinations()
        {
            List<string> l = "lago".GetCombinations();
        }

        [TestMethod]
        public void TestStringCombinations2()
        {
            List<string> l = "123".GetCombinations();
            foreach (string s in l)
                Console.WriteLine(s);
        }
    }
}
