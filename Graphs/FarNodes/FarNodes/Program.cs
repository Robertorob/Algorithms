using System;
using System.Collections.Generic;
using System.Linq;

namespace FarNodes
{
    public class Node
    {
        public int Value { get; set; }
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
                    Value = 1,
                    Neibhs = new List<int>{2}
                },
                new Node
                {
                    Value = 2,
                    Neibhs = new List<int>{1,3}
                },
                new Node
                {
                    Value = 3,
                    Neibhs = new List<int>{2,4,5}
                },
                new Node
                {
                    Value = 4,
                    Neibhs = new List<int>{3}
                },
                new Node
                {
                    Value = 5,
                    Neibhs = new List<int>{3,6}
                },
                new Node
                {
                    Value = 6,
                    Neibhs = new List<int>{5}
                }
            };

            bool[] used = new bool[6];
            int[] lengts = new int[6];

            KeyValuePair<int, int> kv = dfs(g, 0, 0, used);

            bool[] used2 = new bool[6];

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
