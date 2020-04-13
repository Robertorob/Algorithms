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

            PrintPermutation(permutation);

            while (NextPermutation(permutation))
            {
                PrintPermutation(permutation);
            }
        }

        public static bool NextPermutation(char[] permutation)
        {
            // Going through all elements from right and trying to find an element where sequence begins to descend (descendCharIndex).
            int descendCharIndex = 0;
            for (int i = permutation.Length - 1; i > 0; i--)
            {
                if (permutation[i] > permutation[i - 1])
                {
                    descendCharIndex = i - 1;
                    break;
                }

                // Assign index to -1, if there is no permutations left.
                if(permutation[i-1] > permutation[i] && (i-1) == 0)
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
            for (int i = permutation.Length - 1; i >= 0; i--)
            {
                if (permutation[i] > permutation[descendCharIndex])
                {
                    nextCharIndex = i;
                    break;
                }
            }

            Swap(permutation, descendCharIndex, nextCharIndex);
            Array.Reverse(permutation, descendCharIndex + 1, permutation.Length - descendCharIndex - 1);

            return true;
        }

        public static void Swap(char[] array, int x, int y)
        {
            char z = array[x];
            array[x] = array[y];
            array[y] = z;
        }

        public static void PrintPermutation(char[] permutation)
        {
            for (int i = 0; i < permutation.Length; i++)
            {
                Console.Write(permutation[i] + " ");
            }
            Console.WriteLine();
        }

    }
}
