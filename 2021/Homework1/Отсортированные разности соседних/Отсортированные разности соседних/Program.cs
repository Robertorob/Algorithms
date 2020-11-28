using System;
using System.Linq;

namespace Отсортированные_разности_соседних
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while(t != 0)
            {
                int n = int.Parse(Console.ReadLine());

                int[,] diffs = new int[n, n];

                int[] a = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(f => int.Parse(f)).ToArray();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        diffs[i, j] = a[i] - a[j];
                    }
                }

                t--;
            }
        }
    }
}
