using System;
using System.Linq;

namespace EvgeniiAndPlaylist
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string[] mass1 = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(mass1[0]);
            int m = int.Parse(mass1[1]);

            int[] sum = new int[n];

            for (int i = 0; i < n; i++)
            {
                string line2 = Console.ReadLine();
                string[] mass2 = line2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int ci = int.Parse(mass2[0]);
                int ti = int.Parse(mass2[1]);

                if (i == 0)
                    sum[i] = ci * ti;
                else
                    sum[i] = ci * ti + sum[i - 1];
            }

            string line3 = Console.ReadLine();
            string[] mass3 = line3.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] v = mass3.Select(f => BinarySearch(sum, int.Parse(f)) + 1).ToArray();

            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + " ");
            }
        }

        public static int BinarySearch(int[] mass, int value)
        {
            int l = -1, r = mass.Length - 1;

            if (mass[0] >= value)
                return 0;

            if (mass[mass.Length - 1] < value)
                return mass.Length;

            while (l < r + 1)
            {
                int m = (r + l) / 2;

                if (mass[m] == value)
                    return m;

                if (mass[m + 1] == value)
                    return m + 1;

                if (mass[m] < value && mass[m + 1] > value)
                    return m + 1;

                if (mass[m] < value)
                    l = m;
                else
                    r = m;
            }
            return r + 1;
        }
    }
}
