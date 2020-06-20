using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    public class Node
    {
        public Node(int value, int previous, List<Edge> neibhs)
        {
            this.Value = value;
            this.Previous = previous;
            this.Neibhs = neibhs;
        }

        public List<Edge> Neibhs { get; set; }
        public bool Checked { get; set; }
        public int Value { get; set; }
        public int Previous { get; set; }

        public static bool operator <(Node l, Node f)
        {
            return l.Value < f.Value;
        }
        public static bool operator >(Node l, Node f)
        {
            return l.Value > f.Value;
        }
    }

    public class Edge
    {
        public Edge(int vertex, int weight)
        {
            this.Vertex = vertex;
            this.Weight = weight;
        }

        public int Vertex { get; set; }
        public int Weight { get; set; }       
    }
}
