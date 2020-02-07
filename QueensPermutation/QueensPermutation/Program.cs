using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace QueensPermutation
{
    class Program
    {
        public static int count = 0;
        public static int[] massive = new int[8];
        static void Main(string[] args)
        {

            PutQueen(0);
            Console.WriteLine(count);
        }

        public static void PutQueen(int index)
        {
            for (int i = 0; i < 8; i++)
            {
                bool checkDesk = CheckDesk(index, i);
                if (checkDesk && index == 7)
                {
                    count++;
                    return;
                }

                if (checkDesk)
                {
                    massive[index] = i;
                    PutQueen(index + 1);
                }

            }
        }

        public static bool CheckDesk(int index, int value)
        {
            if (index == 0)
                return true;

            for (int i = 0; i < index; i++)
            {
                if (Math.Abs(index - i) == Math.Abs(value - massive[i]) || value == massive[i])
                    return false;
            }
            return true;
        }

    }
}
