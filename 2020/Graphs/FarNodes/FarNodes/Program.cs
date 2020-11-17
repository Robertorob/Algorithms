using System;
using System.Collections.Generic;
using System.Linq;

namespace FarNodes
{
    public class Node
    {
        public List<int> Neibhs { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Node> g = new List<Node>
            {
                new Node
                {
                    Neibhs = new List<int>{2}
                },
                new Node
                {
                    Neibhs = new List<int>{1,3}
                },
                new Node
                {
                    Neibhs = new List<int>{2,4,5}
                },
                new Node
                {
                    Neibhs = new List<int>{3}
                },
                new Node
                {
                    Neibhs = new List<int>{3,6}
                },
                new Node
                {
                    Neibhs = new List<int>{5}
                }
            };

            bool[] used = new bool[g.Count];
            int[] lengts = new int[g.Count];

            KeyValuePair<int, int> kv = dfs(g, 0, 0, used);

            bool[] used2 = new bool[g.Count];

            KeyValuePair<int, int> kv2 = dfs(g, kv.Key, 0, used2);

            Console.WriteLine($"indexMax:{kv.Key + 1}, indexMax2: {kv2.Key + 1}");
            Console.ReadKey();
        }

        public static KeyValuePair<int, int> dfs(List<Node> g, int i, int length, bool[] used)
        {
            used[i] = true;

            int max = length;
            int index = i;

            foreach (var item in g[i].Neibhs)
            {
                if (used[item - 1] == false)
                {
                    KeyValuePair<int, int> kv = dfs(g, item - 1, length + 1, used);
                    if(kv.Value > max)
                    {
                        max = kv.Value;
                        index = kv.Key;
                    }
                }
            }

            return new KeyValuePair<int, int>(index, max);
        }
    }
}
