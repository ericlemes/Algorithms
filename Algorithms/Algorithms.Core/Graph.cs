using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public enum ProcessStatus
    {
        BeforeProcessVertex,
        EdgeProcessed,
        AfterProcessVertex
    }

    public class Graph
    {
        private EdgeNode[] edges;
        public EdgeNode[] FirstEdge
        {
            get { return edges; }            
        }

        private int[] degrees;
        public int[] Degrees
        {
            get { return degrees; }            
        }

        private int nvertices;
        public int NVertices
        {
            get { return nvertices; }            
        }

        private int nedges;
        public int NEdges
        {
            get { return nedges; }            
        }

        private bool directed;
        public bool Directed
        {
            get { return directed; }            
        }

        public Graph(bool directed, int nvertices)
        {
            this.directed = directed;
            this.nvertices = nvertices;
            edges = new EdgeNode[nvertices + 1];
            degrees = new int[nvertices + 1];
        }

        public void Insert(int x, int y)
        {
            Insert(x, y, 0);
        }

        public void Insert(int x, int y, int weight)
        {
            if (x > nvertices)
                throw new Exception("x > nvertices");
            if (y > nvertices)
                throw new Exception("y > nvertices");
            Insert(x, y, weight, this.directed);
        }

        private void Insert(int x, int y, int weight, bool directed)
        {
            EdgeNode edge = new EdgeNode(y, weight, this.edges[x]);
            this.edges[x] = edge;
            this.degrees[x]++;

            if (!directed)
                Insert(y, x, weight, true);
            else
                nedges++;
        }

        public BFSResult BreadthFirstSearch(int start)
        {
            if (start > nvertices)
                throw new Exception("Vertex doesn't exists");

            Queue<int> q = new Queue<int>();
            bool[] processed = new bool[nvertices + 1];
            bool[] discovered = new bool[nvertices + 1];
            int[] parent = new int[nvertices + 1];
            List<SearchResult> result = new List<SearchResult>();

            q.Enqueue(start);
            discovered[start] = true;
            while (q.Count > 0)
            {
                int v = q.Dequeue();
                result.Add(new SearchResult(ProcessStatus.BeforeProcessVertex, v));
                processed[v] = true;
                EdgeNode p = this.edges[v];
                while (p != null)
                {
                    int y = p.Y;
                    if (!processed[y] || this.directed)
                        result.Add(new SearchResult(ProcessStatus.EdgeProcessed, v, y));
                    if (!discovered[y])
                    {
                        q.Enqueue(y);
                        discovered[y] = true;
                        parent[y] = v;
                    }
                    p = p.Next;
                }
                result.Add(new SearchResult(ProcessStatus.AfterProcessVertex, v));
            }
            return new BFSResult(result, parent);
        }

        public BFSResult DepthFirstSearchWithStack(int start)
        {
            if (start > nvertices)
                throw new Exception("Vertex doesn't exists");

            Stack<int> q = new Stack<int>();
            bool[] processed = new bool[nvertices + 1];
            bool[] discovered = new bool[nvertices + 1];
            int[] parent = new int[nvertices + 1];
            List<SearchResult> result = new List<SearchResult>();

            q.Push(start);
            discovered[start] = true;
            while (q.Count > 0)
            {
                int v = q.Pop();
                result.Add(new SearchResult(ProcessStatus.BeforeProcessVertex, v));
                processed[v] = true;
                EdgeNode p = this.edges[v];
                while (p != null)
                {
                    int y = p.Y;
                    if (!processed[y] || this.directed)
                        result.Add(new SearchResult(ProcessStatus.EdgeProcessed, v, y));
                    if (!discovered[y])
                    {
                        q.Push(y);
                        discovered[y] = true;
                        parent[y] = v;
                    }
                    p = p.Next;
                }
                result.Add(new SearchResult(ProcessStatus.AfterProcessVertex, v));
            }
            return new BFSResult(result, parent);
        }

        public BFSResult DepthFirstSearchRecursive(int v)
        {
            bool finished = false;
            bool[] discovered = new bool[nvertices + 1];
            bool[] processed = new bool[nvertices + 1];
            int[] entryTime = new int[nvertices + 1];
            int[] exitTime = new int[nvertices + 1];
            int[] parent = new int[nvertices + 1];
            List<SearchResult> result = new List<SearchResult>();
            List<KeyValuePair<int, int>> backEdges = new List<KeyValuePair<int, int>>();

            DFS(v, ref finished, discovered, entryTime, parent, processed, exitTime, result, backEdges);

            return new BFSResult(result, parent);
        }

        private void DFS(int v, ref bool finished, bool[] discovered, int[] entryTime, 
            int[] parent, bool[] processed, int[] exitTime, List<SearchResult> result, List<KeyValuePair<int, int>> backEdges)
        {
            if (finished)
                return;

            discovered[v] = true;
            entryTime[v]++;

            result.Add(new SearchResult(ProcessStatus.BeforeProcessVertex, v));           

            EdgeNode p = this.edges[v];
            while (p != null)
            {
                int y = p.Y;
                if (!discovered[y])
                {
                    parent[y] = v;
                    result.Add(new SearchResult(ProcessStatus.EdgeProcessed, v, y));
                    CheckBackEdge(backEdges, v, y, discovered, parent);
                    DFS(y, ref finished, discovered, entryTime, parent, processed, exitTime, result, backEdges);
                }
                else if ((!processed[y] && parent[v] != y) || this.directed)
                {
                    result.Add(new SearchResult(ProcessStatus.EdgeProcessed, v, y));
                    CheckBackEdge(backEdges, v, y, discovered, parent);
                }
                if (finished)
                    return;

                p = p.Next;
            }
            result.Add(new SearchResult(ProcessStatus.AfterProcessVertex, v));           

            exitTime[v]++;
            processed[v] = true;
        }

        private void CheckBackEdge(List<KeyValuePair<int, int>> backEdges, int x, int y, bool[] discovered, int[] parent)
        {
            if (discovered[y] && (parent[x] != y))
                backEdges.Add(new KeyValuePair<int, int>(x, y));
        }

        public List<int> FindPath(int src, int dest, int[] parents)
        {
            List<int> result = new List<int>();

            int curr = dest;
            while (parents[curr] > 0)
            {
                result.Add(curr);
                curr = parents[curr];
                if (curr == src)
                    result.Add(curr);
            }
            result.Reverse();
            return result;
        }

        public DijkstraResult Dijkstra(int start)
        {
            bool[] intree = new bool[nvertices + 1];
            int[] distance = new int[nvertices + 1];
            int[] parent = new int[nvertices + 1];            
            

            for (int i = 1; i <= this.nvertices; i++){
                distance[i] = Int32.MaxValue;
            }

            distance[start] = 0;
            int v = start;
            while (!intree[v])
            {
                intree[v] = true;
                EdgeNode p = this.edges[v];
                while (p != null)
                {
                    int w = p.Y;
                    int weight = p.Weight;
                    if (distance[w] > distance[v] + weight)
                    {
                        distance[w] = distance[v] + weight;
                        parent[w] = v;
                    }
                    p = p.Next;
                }

                v = 1;
                int dist = Int32.MaxValue;
                for (int i = 1; i <= this.nvertices; i++)
                {
                    if (!intree[i] && dist > distance[i])
                    {
                        dist = distance[i];
                        v = i;
                    }
                }
            }

            return new DijkstraResult() { Distance = distance, Parent = parent };
        }
    }

    public class EdgeNode
    {
        private int y;
        public int Y
        {
            get { return y; }            
        }

        private int weight;
        public int Weight
        {
            get { return weight; }            
        }

        private EdgeNode next;
        public EdgeNode Next
        {
            get { return next; }
        }

        public EdgeNode(int y, int weight, EdgeNode next)
        {
            this.y = y;
            this.weight = weight;
            this.next = next;
        }
    }

    public class SearchResult
    {
        private ProcessStatus status;
        public ProcessStatus Status
        {
            get { return status; }
        }

        private int vertex;
        public int Vertex
        {
            get { return vertex; }
        }

        private int x;
        public int X
        {
            get { return x; }
        }

        private int y;
        public int Y
        {
            get { return y; }
        }

        public SearchResult(ProcessStatus status, int vertex)
        {
            if (status != ProcessStatus.AfterProcessVertex && status != ProcessStatus.BeforeProcessVertex)
                throw new Exception("Vertex can't be used for ProcessVertex");
            this.status = status;
            this.vertex = vertex;
        }

        public SearchResult(ProcessStatus status, int x, int y)
        {
            if (status != ProcessStatus.EdgeProcessed)
                throw new Exception("X and Y should be used only for EdgeProcessed.");
            this.status = status;
            this.x = x;
            this.y = y;
        }
    }

    public class BFSResult
    {
        private List<SearchResult> searchResult;
        public List<SearchResult> SearchResult
        {
            get { return searchResult; }
        }

        private int[] parents;
        public int[] Parents
        {
            get { return parents; }
        }

        public BFSResult(List<SearchResult> searchResult, int[] parents)
        {
            this.searchResult = searchResult;
            this.parents = parents;
        }
    }

    public class DijkstraResult
    {
        public int[] Parent
        {
            get;
            set;
        }

        public int[] Distance
        {
            get;
            set;
        }
    }

}
