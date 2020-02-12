using System;
using System.Linq;

namespace IvanAndLantern
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string[] mass1 = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(mass1[0]);
            int l = int.Parse(mass1[1]);

            
            string line2 = Console.ReadLine();
            double[] a = line2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(f => double.Parse(f)).ToArray();

            double d = 0;

            Array.Sort(a);

            if (a[0] != 0)
                d = a[0];
            if (a[n - 1] != l)
                d = Max((int) d, l - a[n - 1]);

            for (int i = 0; i < n - 1; i++)
            {
                double radius = (a[i + 1] - a[i]) / 2;
                if(radius > d)
                {
                    d = radius;
                }
            }
            Console.WriteLine(d);
        }

        private static double Max(double x, double y)
        {
            return x > y ? x : y;
        }
    }
}
