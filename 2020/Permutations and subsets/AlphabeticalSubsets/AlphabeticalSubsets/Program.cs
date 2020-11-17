using System;

namespace AlphabeticalSubsets
{
    class Program
    {
        private static int[] d;
        private static int n;
        private static int[] set;

        static void Main(string[] args)
        {
            set = new int[3] { 3, 1, 2 };
            n = 3;
            Array.Sort(set);

            d = new int[set.Length + 1];

            Func(0, -1);
        }

        public static void Func(int j, int prev)
        {
            if(prev == -2)
            {
                for (int i = 0; i < j - 1; i++)
                {
                    Console.Write(d[i] + " ");
                }
                Console.WriteLine();
                
                return;
            }

            Func(j + 1, -2);

            for (int i = prev + 1; i < n; i++)
            {
                d[j] = set[i];
                Func(j + 1, i);
            }
        }
    }
}
