using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = SplitString();

            long n = long.Parse(line1[0]);
            long m = long.Parse(line1[1]);

            long[] a = new long[n];
            long[] diffs = new long[n];

            for (long i = 0; i < n; i++)
            {
                var line = SplitString();

                a[i] = long.Parse(line[0]);
                diffs[i] = a[i] - long.Parse(line[1]);
            }

            long sum = a.Sum();
            Array.Sort(diffs);

            if (sum <= m)
            {
                Console.WriteLine("0");
                return;
            }

            for (long i = diffs.Length - 1; i >= 0; i--)
            {
                sum -= diffs[i];

                if (sum <= m)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("-1");

        }

        public static string[] SplitString()
        {
            return Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
