using System;

namespace RecursivePermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] a = "ABC".ToCharArray();
            Permute(a, 0, a.Length - 1);
            Console.ReadKey();
        }

        public static void Permute(char[] permutation, int index, int lastIndex)
        {
            if (index == lastIndex)
                Print(permutation);
            else
            {
                for (int j = index; j <= lastIndex; j++)
                {
                    Swap(permutation, index, j);
                    Permute(permutation, index + 1, lastIndex);
                    Swap(permutation, index, j);
                }
            }
        }

        public static void Print(char[] array)
        {
            Console.WriteLine(string.Join(' ', array));
        }

        public static void Swap(char[] array, int i, int j)
        {
            char t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }
}
