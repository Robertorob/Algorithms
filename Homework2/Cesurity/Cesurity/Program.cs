using System;

namespace Cesurity
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] mass = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = int.Parse(mass[j]);
                }
            }

            int[,] f = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    f[i, j] = Max(i - 1 >= 0 ? f[i - 1, j] : 0,
                        j - 1 >= 0 ? f[i, j - 1] : 0 
                        ) + a[i, j];
                }
            }
            Console.WriteLine(f[n - 1, n - 1]);
        }

        public static int Max(int x, int y)
        {
            return x > y ? x : y;
        }
    }
}
