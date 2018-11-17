using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Utilities
{
    public static class Dijkstra
    {
        public static int GetShortestPath(Graph graph, Vertex source, Vertex target)
        {
            InitializeSingleSource(graph, source);
            var s = new List<Vertex>();
            var q = new MinimumPriorityQueue<Vertex>(v => v.ShortestPathValue, graph.GetVertices().Count());
            foreach (var vertex in graph.GetVertices()) q.Insert(vertex);
            while (!s.Contains(target))
            {
                var u = q.ExtractMinimum();
                s.Add(u);
                foreach (var v in u.Successors) Relax(q, u, v);
            }

            return target.ShortestPathValue;
        }

        private static void Relax(MinimumPriorityQueue<Vertex> q, Vertex u, Vertex v)
        {
            var newShortestPathValue = u.ShortestPathValue + v.IncomingEdgeValue;
            if (newShortestPathValue < v.ShortestPathValue)
            {
                v.ShortestPathValue = newShortestPathValue;
                v.Predecessor = u;
                q.DecreaseElementPriority(v);
            }
        }

        private static void InitializeSingleSource(Graph graph, Vertex source)
        {
            foreach (var v in graph.GetVertices())
            {
                v.ShortestPathValue = int.MaxValue;
                v.Predecessor = null;
            }

            source.ShortestPathValue = source.IncomingEdgeValue;
        }
    }

    public class Vertex
    {
        public Vertex(int incomingEdgeValue)
        {
            IncomingEdgeValue = incomingEdgeValue;
            Successors = new List<Vertex>();
        }

        public int ShortestPathValue { get; set; }

        public int IncomingEdgeValue { get; }

        public Vertex Predecessor { get; set; }

        public List<Vertex> Successors { get; set; }

        public override string ToString()
        {
            return IncomingEdgeValue.ToString();
        }
    }

    public class Graph
    {
        private readonly IEnumerable<Vertex> _vertices;

        public Graph(IEnumerable<Vertex> vertices)
        {
            _vertices = vertices;
        }

        public IEnumerable<Vertex> GetVertices()
        {
            return _vertices;
        }
    }
}