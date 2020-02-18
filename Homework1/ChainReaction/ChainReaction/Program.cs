using System;

namespace ChainReaction
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int n = int.Parse(line1);

            int[] a = new int[n];
            int[] b = new int[n];

            int[] field = new int[1000000];

            for (int i = 0; i < n; i++)
            {
                string line2 = Console.ReadLine();
                string[] mass2 = line2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int ai = int.Parse(mass2[0]);
                int bi = int.Parse(mass2[1]);
                a[i] = ai;
                b[i] = bi;
                field[ai] = bi;
            }

            int min = int.MaxValue;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int count = Count(a, b, i, field) + (a.Length - 1 - i);
                if (count < min)
                    min = count;
            }
            Console.WriteLine(min);
        }

        public static int Count(int[] a, int[] b, int index, int[] field)
        {
            int count = 0;
            int tempCount = 0;

            for (int i = index; i >= 0; i = i - tempCount - 1)
            {
                int ai = a[i];
                int bi = b[i];

                tempCount = 0;
                for (int j = ai - 1; j >= ai - bi && j >= 0; j--)
                {
                    if (field[j] > 0)
                    {
                        count++;
                        tempCount++;
                    }                      
                }
            }

            return count;
        }
    }
}
