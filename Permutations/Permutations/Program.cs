using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] massive = new int[] { 1,1,1,4};


            bool flag = NextPermutation(massive);
            int amount = 1;
            while (flag)
            {
                Console.Write(amount + ": ");
                for (int i = 0; i < massive.Length; i++)
                {
                    Console.Write(massive[i] + " ");
                }
                Console.WriteLine();
                flag = NextPermutation(massive);
                amount++;
            }
        }

        public static bool NextPermutation(int[] mass)
        {
            int index = 0;

            for (int i = mass.Length - 1; i > 0; i--)
            {
                if (mass[i] > mass[i - 1])
                {
                    index = i - 1;
                    break;
                }

                if(mass[i-1] > mass[i] && (i-1) == 0)
                {
                    index = -1;
                }
            }

            if(index == -1)
            {
                return false;
            }

            int index2 = 0;
            for (int i = mass.Length - 1; i >= 0; i--)
            {
                if (mass[i] > mass[index])
                {
                    index2 = i;
                    break;
                }
            }

            mass = Swap(mass, index, index2);
            Array.Reverse(mass, index + 1, mass.Length - index - 1);

            return true;
        }

        public static int[] Swap(int[] mass, int x, int y)
        {
            int z = mass[x];
            mass[x] = mass[y];
            mass[y] = z;

            return mass;
        }

    }
}
