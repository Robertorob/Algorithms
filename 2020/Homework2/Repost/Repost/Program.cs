using System;
using System.Collections.Generic;

namespace Repost
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> names = new Dictionary<string, int>(n + 1);
            names.Add("polycarp", 1);
            int maxLength = 1;

            for (int i = 0; i < n; i++)
            {
                string[] massive = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string who = massive[0].ToLower();
                string whom = massive[2].ToLower();

                int currentLength = names[whom] + 1;
                names.Add(who, currentLength);
                maxLength = Max(maxLength, currentLength);
            }
            Console.WriteLine(maxLength);
        }

        public static int Max(int x, int y)
        {
            return x > y ? x : y;
        }
    }   
}
