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
                new Node(0,             new Edge(5, 14), new Edge(1, 7), new Edge(2, 9)),
                new Node(int.MaxValue,  new Edge(0, 7), new Edge(2, 10), new Edge(3, 15)),
                new Node(int.MaxValue,  new Edge(0, 9), new Edge(1, 10), new Edge(3, 11), new Edge(5, 2)),
                new Node(int.MaxValue,  new Edge(1, 15), new Edge(2, 11), new Edge(4, 6)),
                new Node(int.MaxValue,  new Edge(5, 9), new Edge(3, 6) ),
                new Node(int.MaxValue,  new Edge(0, 14), new Edge(2, 2), new Edge(4, 9))
            };

            MinHeap heap = new MinHeap();

            Node node = g[0];

            while(true)
            {
                node.Checked = true;

                foreach (var n in node.Neibhs)
                {
                    if (g[n.NodeNumber].Checked)
                        continue;

                    g[n.NodeNumber].Value = Min(n.Weight + node.Value, g[n.NodeNumber].Value);
                    heap.Add(g[n.NodeNumber]);
                }

                //g[minEdge.Vertex].Value = 

                node = heap.GetMin();

                if (node == null)
                    break;

                //break;

            }

            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine($"{i} - {g[i].Value}");
            }

            Console.ReadKey();
        }

        public static int Min(int x, int y)
        {
            return x < y ? x : y;
        }
    }
}
