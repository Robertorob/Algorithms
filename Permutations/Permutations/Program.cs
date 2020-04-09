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
            string input = "aabc";

            PrintAllPermutations(input);
        }

        public static void PrintAllPermutations(string input)
        {
            char[] permutation = input.ToArray();
            Array.Sort(permutation);

            PrintPermutation(permutation, 1);

            int permutationIndex = 2;
            while (NextPermutation(permutation))
            {
                PrintPermutation(permutation, permutationIndex);
                permutationIndex++;
            }
        }

        public static bool NextPermutation(char[] mass)
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

            Swap(mass, index, index2);
            Array.Reverse(mass, index + 1, mass.Length - index - 1);

            return true;
        }

        public static void Swap(char[] mass, int x, int y)
        {
            char z = mass[x];
            mass[x] = mass[y];
            mass[y] = z;
        }

        public static void PrintPermutation(char[] permutation, int permutationIndex)
        {
            Console.Write(permutationIndex + ": ");
            for (int i = 0; i < permutation.Length; i++)
            {
                Console.Write(permutation[i] + " ");
            }
            Console.WriteLine();
        }

    }
}
