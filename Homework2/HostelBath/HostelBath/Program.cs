using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HostelBath
{
    class Program
    {
        public static int count = 0;
        public static int n = 5;
        public static int[] massive = new int[n];
        public static int[,] g = new int[n, n];
        public static int max = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    g[i, j] = int.Parse(line[j]);
                }
            }

            ChooseValueForPermutation(0);
            Console.WriteLine(max);
        }

        public static void ChooseValueForPermutation(int index)
        {
            for (int i = 0; i < n; i++)
            {
                bool checkDesk = CheckDesk(index, i);
                massive[index] = i;
                if (checkDesk && index == n - 1)
                {
                    int temp = SumOfHappiness();
                    if (temp > max)
                        max = temp;
                    return;
                }

                if (checkDesk)
                {                  
                    ChooseValueForPermutation(index + 1);
                }

            }
        }

        public static int SumOfHappiness()
        {
            return g[massive[0], massive[1]] + g[massive[1], massive[0]] +
                    2 * (g[massive[2], massive[3]] + g[massive[3], massive[2]]) +
                    g[massive[1], massive[2]] + g[massive[2], massive[1]] +
                    2 * (g[massive[3], massive[4]] + g[massive[4], massive[3]]);
        }

        public static bool CheckDesk(int index, int value)
        {
            if (index == 0)
                return true;

            for (int i = 0; i < index; i++)
            {
                if (massive[i] == value)
                    return false;
            }
            return true;
        }
    }
}
