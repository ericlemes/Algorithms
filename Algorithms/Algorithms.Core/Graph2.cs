using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class Edge<T>
    {
        public T Item
        {
            get;
            set;
        }

        private List<Vertex<T>> vertices = new List<Vertex<T>>();
        public List<Vertex<T>> Vertices
        {
            get { return vertices; }
        }
    }

    public class Vertex<T>
    {
        public Edge<T> Edge
        {
            get;
            set;
        }

        public int Weight
        {
            get;
            set;
        }
    }

    public class Node<T>
    {
        public Edge<T> Edge
        {
            get;
            set;
        }

        public int Weight
        {
            get;
            set;
        }
    }

    public delegate bool IsInStopConditionDelegate<T>(List<Node<T>> route);

    public static class Graph2
    {
        public static List<List<Node<T>>> CalculateAllRoutes<T>(Edge<T> startEdge, Edge<T> endEdge,
            IsInStopConditionDelegate<T> isInStopCondition)
        {
            List<List<Node<T>>> allRoutes = new List<List<Node<T>>>();
            List<Node<T>> currRoute = new List<Node<T>>();
            Node<T> n = new Node<T> { Edge = startEdge, Weight = 0 };
            currRoute.Add(n);
            CalculateRoutesFor(allRoutes, currRoute, startEdge, endEdge, isInStopCondition);
            return allRoutes;
        }

        private static void CalculateRoutesFor<T>(List<List<Node<T>>> routes, List<Node<T>> currRoute, Edge<T> startEdge,
            Edge<T> endEdge, IsInStopConditionDelegate<T> isInStopCondition)
        {
            foreach (Vertex<T> v in startEdge.Vertices)
            {
                List<Node<T>> tmpRoute = new List<Node<T>>(currRoute);
                Node<T> n = new Node<T> { Edge = v.Edge, Weight = v.Weight };
                tmpRoute.Add(n);
                if (v.Edge == endEdge)
                    routes.Add(tmpRoute);
                if (!isInStopCondition(tmpRoute))
                    CalculateRoutesFor(routes, tmpRoute, v.Edge, endEdge, isInStopCondition);
            }
        }

        public static string PrintRoute<T>(List<Node<T>> route)
        {
            StringBuilder s = new StringBuilder(route.Count * 3);
            foreach (Node<T> n in route)
            {
                if (s.Length > 0)
                    s.Append(" ");
                s.Append(n.Edge.Item.ToString());
                s.Append(n.Weight.ToString());                
            }
            return s.ToString();
        }
    }
}
