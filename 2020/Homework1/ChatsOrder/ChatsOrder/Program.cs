using System;
using System.Collections.Generic;

namespace ChatsOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int n = int.Parse(line1);

            string[] names = new string[n];
            for (int i = 0; i < n; i++)
            {
                names[i] = Console.ReadLine();
            }

            Dictionary<string, string> namesSet = new Dictionary<string, string>(n);

            for (int i = names.Length - 1; i >= 0; i--)
            {
                if (!namesSet.ContainsKey(names[i]))
                {
                    Console.WriteLine(names[i]);
                    namesSet.Add(names[i], null);
                }                    
            }
        }
    }
}
