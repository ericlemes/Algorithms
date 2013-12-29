using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Core;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class Graph2Tests
    {        
        [TestMethod]
        public void CalculateAllRoutes1Test()
        {
            Edge<string> edgeA = new Edge<string> { Item = "A" };
            Edge<string> edgeB = new Edge<string> { Item = "B" };
            Edge<string> edgeC = new Edge<string> { Item = "C" };
            Edge<string> edgeD = new Edge<string> { Item = "D" };
            Edge<string> edgeE = new Edge<string> { Item = "E" };
            edgeA.Vertices.Add(new Vertex<string> { Edge = edgeB, Weight = 1 });
            edgeA.Vertices.Add(new Vertex<string> { Edge = edgeC, Weight = 2 });
            edgeB.Vertices.Add(new Vertex<string> { Edge = edgeD, Weight = 3 });
            edgeC.Vertices.Add(new Vertex<string> { Edge = edgeD, Weight = 4 });
            edgeC.Vertices.Add(new Vertex<string> { Edge = edgeE, Weight = 4 });
            edgeE.Vertices.Add(new Vertex<string> { Edge = edgeA, Weight = 1 });
           
            List<List<Node<string>>> routes = Graph2.CalculateAllRoutes(edgeA, edgeA, (r) => { return r.Count >= 3; });
            Assert.AreEqual(0, routes.Count);

        }

        [TestMethod]
        public void CalculateAllRoutes2Test()
        {
            Edge<string> edgeA = new Edge<string> { Item = "A" };
            Edge<string> edgeB = new Edge<string> { Item = "B" };
            Edge<string> edgeC = new Edge<string> { Item = "C" };
            Edge<string> edgeD = new Edge<string> { Item = "D" };
            Edge<string> edgeE = new Edge<string> { Item = "E" };
            edgeA.Vertices.Add(new Vertex<string> { Edge = edgeB, Weight = 1 });
            edgeA.Vertices.Add(new Vertex<string> { Edge = edgeC, Weight = 2 });
            edgeB.Vertices.Add(new Vertex<string> { Edge = edgeD, Weight = 3 });
            edgeC.Vertices.Add(new Vertex<string> { Edge = edgeD, Weight = 4 });
            edgeC.Vertices.Add(new Vertex<string> { Edge = edgeE, Weight = 4 });
            edgeD.Vertices.Add(new Vertex<string> { Edge = edgeE, Weight = 2 });
            edgeE.Vertices.Add(new Vertex<string> { Edge = edgeA, Weight = 1 });

            List<List<Node<string>>> routes = Graph2.CalculateAllRoutes(edgeA, edgeA, (r) => { return r.Count >= 5; });
            Assert.AreEqual(3, routes.Count);
            Assert.AreEqual("A0 B1 D3 E2 A1", Graph2.PrintRoute(routes[0]));
            Assert.AreEqual("A0 C2 D4 E2 A1", Graph2.PrintRoute(routes[1]));
            Assert.AreEqual("A0 C2 E4 A1", Graph2.PrintRoute(routes[2]));
        }

        [TestMethod]
        public void CalculateAllRoutes3Test()
        {
            Edge<string> edgeA = new Edge<string> { Item = "A" };
            Edge<string> edgeB = new Edge<string> { Item = "B" };
            Edge<string> edgeC = new Edge<string> { Item = "C" };
            Edge<string> edgeD = new Edge<string> { Item = "D" };
            Edge<string> edgeE = new Edge<string> { Item = "E" };
            edgeA.Vertices.Add(new Vertex<string> { Edge = edgeB, Weight = 1 });
            edgeA.Vertices.Add(new Vertex<string> { Edge = edgeC, Weight = 2 });
            edgeB.Vertices.Add(new Vertex<string> { Edge = edgeD, Weight = 3 });
            edgeC.Vertices.Add(new Vertex<string> { Edge = edgeD, Weight = 4 });
            edgeC.Vertices.Add(new Vertex<string> { Edge = edgeE, Weight = 4 });
            edgeD.Vertices.Add(new Vertex<string> { Edge = edgeE, Weight = 2 });
            edgeE.Vertices.Add(new Vertex<string> { Edge = edgeA, Weight = 1 });

            List<List<Node<string>>> routes = Graph2.CalculateAllRoutes(edgeA, edgeA, 
                (r) => { return r.Sum( (n) => {return n.Weight;}) > 7;}
                );
            Assert.AreEqual(2, routes.Count);
            Assert.AreEqual("A0 B1 D3 E2 A1", Graph2.PrintRoute(routes[0]));            
            Assert.AreEqual("A0 C2 E4 A1", Graph2.PrintRoute(routes[1]));
        }
    }
}
