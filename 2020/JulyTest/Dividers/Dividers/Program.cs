using System;
using System.Collections.Generic;

namespace Dividers
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            long n = long.Parse(line);
            var line2 = Console.ReadLine().Split(new char[] { ' ' });

            long[] arr = new long[10010];

            long max = 0;
            Dictionary<long, long> dic = new Dictionary<long, long>();
            for (int i = 0; i < line2.Length; i++)
            {
                long element = long.Parse(line2[i]);
                if (element > max)
                    max = element;

                if(!dic.ContainsKey(element))
                    dic.Add(element, element);

                arr[element]++;
            }

            long x = max;

            long y = 0;

            if (arr[max] == 2)
                y = max;
            else
            {
                foreach (var item in dic)
                {
                    if (arr[item.Key] == 2 || x % item.Key != 0)
                    {
                        if (item.Key > y)
                            y = item.Key;
                    }
                }
            }

            Console.WriteLine(x + " " + y);
        }
    }
}
