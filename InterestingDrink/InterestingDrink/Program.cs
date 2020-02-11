using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace InterestingDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] x = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(f => int.Parse(f)).ToArray();
            int q = int.Parse(Console.ReadLine());

            int[] m = new int[q];

            Array.Sort(x);

            for (int i = 0; i < q; i++)
            {
                m[i] = BinarySearch(x, int.Parse(Console.ReadLine()) );
            }

            for (int i = 0; i < q; i++)
            {
                Console.WriteLine(m[i]);
            }

            
        }

        public static int BinarySearch(int[] mass, int value)
        {
            int l = -1, r = mass.Length - 1;

            if (mass[0] > value)
                return 0;

            if (mass[mass.Length - 1] <= value)
                return mass.Length;

            while (l < r + 1)
            {
                int m = (r + l) / 2;
                if (mass[m] <= value && mass[m + 1] > value)
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
