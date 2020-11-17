using System;

namespace NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[7] { 1, 2, 3, 7, 6, 5, 4 };
            solve2(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void swap(int[] ar, int i, int j)
        {
            var tmp = ar[i];
            ar[i] = ar[j];
            ar[j] = tmp;
        }


        static void solve2(int[] ar)
        {
            int n = ar.Length;
            var j = n - 2;
            while (j >= 0 && ar[j] > ar[j + 1])
            {
                j--;
            }

            if (j != -1)
            {
                var i = j + 1;
                var k = ar[j];
                while (i < n && ar[i] > k)
                {
                    i++;
                };

                swap(ar, j, i - 1);
            }

            Array.Reverse(ar, j + 1, n - j - 1);
        }
    }
}
