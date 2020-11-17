using System;
using System.Collections.Generic;

namespace TasksOrder_Graphs_
{
    public class Task
    {
        public List<int> Neib { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>
            {
                new Task
                {
                    Neib = new List<int> { 1, 2 }
                }
            };
        }
    }
}
