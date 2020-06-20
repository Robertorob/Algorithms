using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Nim
{
    public enum Result { Loss, Win }

    public class Node
    {
        public Node(params int[] nodes)
        {
            this.Neibhs = new List<int>();
            this.Neibhs.AddRange(nodes);
        }

        public Result Result { get; set; }

        public List<int> Neibhs { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Nim!");

            List<Node> g = new List<Node>
            {
                new Node(),//       0
                new Node(0),//      1
                new Node(1),//      2
                new Node(0),//      3
                new Node(),//       4
                new Node(2,3), //   5
                new Node(3), //     6
                new Node(), //     7
                new Node(5,6,7), // 8
                new Node(), //      9 
                new Node(8)//    10
            };

            var asdf = GetResult(g, 10);

            Console.WriteLine();

            var fsda = GetResult(g, 7);

            Console.ReadKey();
        }

        public static Result GetResult(List<Node> g, int n)
        {
            if (!g[n].Neibhs.Any())
            {
                Console.WriteLine($"{n} - {Result.Loss}");
                return Result.Loss;
            }

            if (g[n].Neibhs.Any(f => GetResult(g, f) == Result.Loss))
            {
                Console.WriteLine($"{n} - {Result.Win}");
                return Result.Win;
            }


            Console.WriteLine($"{n} - {Result.Loss}");
            return Result.Loss;
        }
    }
}
