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
            // Going through all elements from right and trying to find an element where sequence begins to descend (descendCharIndex).
            int descendCharIndex = 0;
            for (int i = mass.Length - 1; i > 0; i--)
            {
                if (mass[i] > mass[i - 1])
                {
                    descendCharIndex = i - 1;
                    break;
                }

                // Assign index to -1, if there is no permutations left.
                if(mass[i-1] > mass[i] && (i-1) == 0)
                {
                    descendCharIndex = -1;
                }
            }

            if(descendCharIndex == -1)
            {
                return false;
            }

            // Going through all elements from right and trying to find the next character after the sequence-begins-to-descend character.
            int nextCharIndex = 0;
            for (int i = mass.Length - 1; i >= 0; i--)
            {
                if (mass[i] > mass[descendCharIndex])
                {
                    nextCharIndex = i;
                    break;
                }
            }

            Swap(mass, descendCharIndex, nextCharIndex);
            Array.Reverse(mass, descendCharIndex + 1, mass.Length - descendCharIndex - 1);

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
            Console.Write(permutationIndex + ":\t");
            for (int i = 0; i < permutation.Length; i++)
            {
                Console.Write(permutation[i] + " ");
            }
            Console.WriteLine();
        }

    }
}
