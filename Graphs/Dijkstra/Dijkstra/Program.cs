using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Dijkstra
{
    public class Node
    {
        public List<int> Neibhs { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dijkstra!");

            List<Node> g = new List<Node>
            {
                new Node
                {
                    Neibhs = {1}
                },
                new Node
                {
                    Neibhs = {1}
                },
                new Node
                {
                    Neibhs = {1}
                },
                new Node
                {
                    Neibhs = {1}
                },
                new Node
                {
                    Neibhs = {1}
                },
                new Node
                {
                    Neibhs = {1}
                },
            };

            Console.ReadKey();
        }
    }
}
