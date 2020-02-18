using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SearchingCodeForce
{
    class Program
    {
        //private static string path = @"D:\Repos\Algorithms\Searching (CodeForce)\Searching (CodeForce)\arrays.txt";
        private static string resultPath = @"D:\Repos\Algorithms\Searching (CodeForce)\Searching (CodeForce)\result.txt";
        static void Main(string[] args)
        {
            int lengthA = int.Parse(Console.ReadLine());
            string[] aString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[lengthA];
            for (int i = 0; i < lengthA; i++)
            {
                a[i] = int.Parse(aString[i]);
            }

            int lengthQ = int.Parse(Console.ReadLine());
            string[] qString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] q = new int[lengthQ];
            for (int i = 0; i < lengthQ; i++)
            {
                q[i] = int.Parse(qString[i]);
            }

            a = a.OrderBy(f => f).ToArray();
            StringBuilder line = new StringBuilder("");
            for (int i = 0; i < lengthQ; i++)
            {
                line.Append(BinarySearch(a, q[i]) + " ");
            }
            Console.WriteLine(line);

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
                if (mass[m] < value && mass[m + 1] >= value)
                    return m + 1;

                if (mass[m] < value)
                    l = m;
                else
                    r = m;
            }
            return r + 1;
        }

        public static void OutputConsole(int[] array, string name)
        {
            Console.WriteLine(name);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
