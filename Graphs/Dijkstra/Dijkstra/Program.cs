using System;
using System.Collections.Generic;
using System.IO;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dijkstra!");

            Node[] g = new Node[6]
            {
                new Node(0,            0, new List<Edge> { new Edge(5, 14), new Edge(1, 7), new Edge(2, 9) }),
                new Node(int.MaxValue, 0, new List<Edge> { new Edge(0, 7), new Edge(2, 10), new Edge(3, 15) }),
                new Node(int.MaxValue, 0, new List<Edge> { new Edge(0, 9), new Edge(1, 10), new Edge(3, 11), new Edge(5, 2) }),
                new Node(int.MaxValue, 0, new List<Edge> { new Edge(1, 15), new Edge(2, 11), new Edge(4, 6) }),
                new Node(int.MaxValue, 0, new List<Edge> { new Edge(5, 9), new Edge(3, 6) }),
                new Node(int.MaxValue, 0, new List<Edge>{ new Edge(0, 14), new Edge(2, 2), new Edge(4, 9) })
            };

            MinHeap heap = new MinHeap(g);

            Node node = heap.GetMin();

            while(true)
            {
                node.Checked = true;

                foreach (var neib in node.Neibhs)
                {

                }

                //g[minEdge.Vertex].Value = Min(minEdge.Weight + node.Value, g[minEdge.Vertex].Value);

                break;

            }

            Console.ReadKey();
        }

        public static int Min(int x, int y)
        {
            return x < y ? x : y;
        }
    }
}
