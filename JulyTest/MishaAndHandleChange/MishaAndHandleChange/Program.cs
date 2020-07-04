using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine());

            if (q == 1)
            {
                var asdf = Console.ReadLine();
                Console.WriteLine("1");
                Console.WriteLine(asdf);
                return;
            }

            Dictionary<string, string> list = new Dictionary<string, string>();

            for (int i = 0; i < q; i++)
            {
                string value;
                var line = Console.ReadLine().Split(new char[] { ' ' });
                if (list.TryGetValue(line[0], out value))
                {
                    list.Remove(line[0]);
                    list.Add(line[1], value);
                }
                else
                    list.Add(line[1], line[0]);
            }

            Console.WriteLine(list.Count);
            foreach (var item in list)
            {
                Console.WriteLine(item.Value + " " + item.Key);
            }


        }
    }
}
