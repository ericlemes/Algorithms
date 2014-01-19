using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Collections.Generic;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void AddWordsTest1()
        {
            Trie t = new Trie();
            t.Add("test");
            t.Add("train");
            t.Add("abc");

            Assert.AreEqual('t', t.FindChild('t').FindChild('e').FindChild('s').FindChild('t').Data);
            Assert.AreEqual('c', t.FindChild('a').FindChild('b').FindChild('c').Data);            
        }

        [TestMethod]
        public void EnumerateWords()
        {
            Trie t = new Trie();
            t.Add("test");
            t.Add("train");
            t.Add("task");

            Trie te = t.FindPrefix("te");
            Assert.AreEqual('e', te.Data);

            Trie ta = t.FindPrefix("ta");
            Assert.AreEqual('a', ta.Data);

            List<string> words = t.EnumerateWords("t");
            Assert.AreEqual("test", words[0]);
            Assert.AreEqual("train", words[1]);
            Assert.AreEqual("task", words[2]);

            words = t.EnumerateWords("tr");
            Assert.AreEqual("train", words[0]);
        }


    }
}
