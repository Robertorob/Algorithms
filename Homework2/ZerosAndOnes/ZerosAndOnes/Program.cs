using System;
using System.Linq;

namespace ZerosAndOnes
{
    class Program
    {
        public static int count = 0;
        public static int[] massive;
        public static int n;
        public static int k;

        static void Main(string[] args)
        {
            string[] mass = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(mass[0]);
            k = int.Parse(mass[1]);
            massive = new int[n];


            if (k > n)
            {
                Console.WriteLine(0);
                return;
            }

            if(k == 1)
            {
                Console.WriteLine(n * n);
                return;
            }

            PutQueen(0);
            Console.WriteLine(count);
        }

        public static void PutQueen(int index)
        {
            for (int i = -1; i < n; i++)
            {
                massive[index] = i;
                bool checkDesk = CheckDesk(index, i);
                if (checkDesk && index == n - 1)
                {
                    count++;
                    continue;
                }

                if (checkDesk)
                {
                    PutQueen(index + 1);
                }

            }
        }

        public static bool CheckDesk(int index, int value)
        {
            //int[,] matrix = new int[n, n];

            

            if (index == 0)
            {
                if(value != -1)
                {
                    return true;
                }
            }  

            if (value != -1)
            {
                int sumNonZeros = 0;
                for (int i = 0; i < index; i++)
                {
                    if (massive[i] == -1)
                        continue;
                    else
                        sumNonZeros++;

                    if (Math.Abs(index - i) == Math.Abs(value - massive[i]) || value == massive[i])
                        return false;
                }
                if (sumNonZeros + 1 > k)
                    return false;
            }
            if(value == -1)
            {
                int sumZeros = 0;

                for (int i = 0; i < index; i++)
                {
                    if (massive[i] == -1)
                    {
                        sumZeros++;
                    } 
                }
                if (sumZeros + 1 > n - k)
                    return false;
            }

            //#region 
            //if (index == n - 1)
            //{
            //    for (int i = 0; i < n; i++)
            //    {
            //        if (massive[i] == -1)
            //            continue;
            //        matrix[massive[i], i] = 1;
            //    }
            //    for (int i = 0; i < n; i++)
            //    {
            //        for (int j = 0; j < n; j++)
            //        {
            //            Console.Write(matrix[i,j] + " ");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}
            //#endregion

            return true;
        }
    }
}