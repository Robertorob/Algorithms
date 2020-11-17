using System;
using System.Linq;

namespace WorldChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var line = Console.ReadLine().Split(new char[] { ' ' }).Select(f => int.Parse(f)).ToList();

            //int count = 0;
            //for (int i = 0; true; i++)
            //{
            //    if(line[i % line.Count] - count <= 0)
            //    {
            //        Console.WriteLine((i % line.Count) + 1);
            //        return;
            //    }
            //    count++;
            //}

            int[] min = new int[n];
            int m = int.MaxValue;
            int indexM = -1;
            for (int i = 0; i < line.Count; i++)
            {
                int shift = line[i] - i;
                int count = shift / n;
                if (shift % n > 0)
                    count++;

                if (shift > 0 && count < 1)
                    count++;

                int steps = i +  (n * (count));

                min[i] = steps;

                if(steps < m)
                {
                    m = steps;
                    indexM = i + 1;
                }
            }

            Console.WriteLine(indexM);
        }
    }
}
