using System;
using System.Linq;

namespace Fence
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mass = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(mass[0]);
            int k = int.Parse(mass[1]);

            int[] a = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(f => int.Parse(f)).ToArray();

            if(k == n)
            {
                Console.WriteLine(1);
                return;
            }
                

            int sum = 0;
            int first = a[0];
            for (int i = 0; i < k; i++)
            {
                sum += a[i];
            }

            int min = sum;
            int index = 0;
            for (int i = k; i < n; i++)
            {
                sum = sum - first + a[i];
                first = a[i - k + 1];
                if (sum < min)
                {
                    min = sum;
                    index = i - k + 1;
                }
            }

            Console.WriteLine(index + 1);
        }
    }
}
