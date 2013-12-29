using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void TestBFS()
        {
            Graph g = new Graph(false, 6);
            g.Insert(1, 2);
            g.Insert(1, 5);
            g.Insert(1, 6);
            g.Insert(2, 3);
            g.Insert(2, 5);
            g.Insert(3, 4);
            g.Insert(5, 4);
            BFSResult bfsResult = g.BreadthFirstSearch(1);
            List<SearchResult> result = bfsResult.SearchResult.Where(l => l.Status == ProcessStatus.AfterProcessVertex).ToList<SearchResult>();
            Assert.AreEqual(1, result[0].Vertex);
            Assert.AreEqual(6, result[1].Vertex);
            Assert.AreEqual(5, result[2].Vertex);
            Assert.AreEqual(2, result[3].Vertex);
            Assert.AreEqual(4, result[4].Vertex);
            Assert.AreEqual(3, result[5].Vertex);
        }

        [TestMethod]
        public void TestFindShortestRoute()
        {
            Graph g = new Graph(false, 6);
            g.Insert(1, 2);
            g.Insert(1, 5);
            g.Insert(1, 6);
            g.Insert(2, 3);
            g.Insert(2, 5);
            g.Insert(3, 4);
            g.Insert(5, 4);
            BFSResult bfsResult = g.BreadthFirstSearch(1);

            List<int> routeTo6 = g.FindPath(1, 6, bfsResult.Parents);
            Assert.AreEqual(1, routeTo6[0]);
            Assert.AreEqual(6, routeTo6[1]);

            List<int> routeTo5 = g.FindPath(1, 5, bfsResult.Parents);
            Assert.AreEqual(1, routeTo5[0]);
            Assert.AreEqual(5, routeTo5[1]);

            List<int> routeTo4 = g.FindPath(1, 4, bfsResult.Parents);
            Assert.AreEqual(1, routeTo4[0]);
            Assert.AreEqual(5, routeTo4[1]);
            Assert.AreEqual(4, routeTo4[2]);

        }

        [TestMethod]
        public void TestDFS()
        {
            Graph g = new Graph(false, 6);
            g.Insert(1, 2);
            g.Insert(1, 5);
            g.Insert(1, 6);
            g.Insert(2, 3);
            g.Insert(2, 5);
            g.Insert(3, 4);
            g.Insert(5, 4);
            BFSResult bfsResult = g.DepthFirstSearchWithStack(1);
            List<SearchResult> result = bfsResult.SearchResult.Where(l => l.Status == ProcessStatus.AfterProcessVertex).ToList<SearchResult>();
            Assert.AreEqual(1, result[0].Vertex);
            Assert.AreEqual(2, result[1].Vertex);
            Assert.AreEqual(3, result[2].Vertex);
            Assert.AreEqual(4, result[3].Vertex);
            Assert.AreEqual(5, result[4].Vertex);
            Assert.AreEqual(6, result[5].Vertex);
        }

        [TestMethod]
        public void TestDFSRecursive()
        {
            Graph g = new Graph(false, 6);
            g.Insert(1, 2);
            g.Insert(1, 5);
            g.Insert(1, 6);
            g.Insert(2, 3);
            g.Insert(2, 5);
            g.Insert(3, 4);
            g.Insert(5, 4);
            BFSResult bfsResult = g.DepthFirstSearchRecursive(1);
            List<SearchResult> result = bfsResult.SearchResult.Where(l => l.Status == ProcessStatus.AfterProcessVertex).ToList<SearchResult>();            
        }

        [TestMethod]
        public void TestDjkstra()
        {
            Graph g = new Graph(false, 6);
            g.Insert(1, 2, 1);
            g.Insert(2, 3, 1);
            g.Insert(3, 6, 2);
            g.Insert(1, 3, 4);
            g.Insert(1, 4, 2);
            g.Insert(4, 5, 1);
            g.Insert(5, 3, 3);
            DijkstraResult r = g.Dijkstra(1);

            Assert.AreEqual(1, r.Distance[2]);
            Assert.AreEqual(2, r.Distance[3]);

            Assert.AreEqual(2, r.Parent[3]);
            Assert.AreEqual(1, r.Parent[2]);
        }
    }

}
