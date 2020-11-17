using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Barcode
{
    class Program
    {
        private static int x;
        private static int y;
        private static int n;
        private static int m;
        private static char[,] matrix;

        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(new char[] { ' ' }).Select(f => int.Parse(f)).ToList();
            n = line[0];
            m = line[1];
            x = line[2];
            y = line[3];

            matrix = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                var line1 = Console.ReadLine().ToCharArray();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = line1[j];
                }
            }

            int shift;
            for (int i = 0; i < m; i += shift)
            {
                int minimum = GetMinimum(i, out shift);
            }
        }

        public static int GetMinimum(int index, out int width)
        {
            width = y;

            int minimum = n * m;
            for (int i = x; i <= y; i++)
            {
                var minimumForThatWidth = GetMinimum(index, width: i);
                if(minimumForThatWidth < minimum)
                {
                    minimum = minimumForThatWidth;
                    width = i;
                }
            }

            return minimum;
        }

        public static int GetBlackCount(int index, int width)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = index; j < index + width; j++)
                {
                    if (matrix[i, j] == '#')
                        count++;
                }
            }

            return count;
        }

        public static int GetMinimum(int index, int width)
        {
            int blackCount = GetBlackCount(index, width);
            return Math.Min(blackCount, n * width - blackCount);
        }
    }
}
