using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    public class Node
    {
        public Node(int value, params Edge [] neibhs)
        {
            this.Value = value;
            this.Neibhs = new List<Edge>();
            this.Neibhs.AddRange(neibhs.ToList());
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
        public Edge(int nodeNumber, int weight)
        {
            this.NodeNumber = nodeNumber;
            this.Weight = weight;
        }

        public int NodeNumber { get; set; }
        public int Weight { get; set; }       
    }
}
