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
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("String is empty");
                return;
            }

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
            // 123 654 -> 124 653 -> 124 356
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
                if(i - 1 == 0)
                {
                    return false;
                }
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
            Console.WriteLine(string.Join("", permutation));
        }

    }
}
