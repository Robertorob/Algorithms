using System;
using System.Linq;

namespace Меньшие_или_равные
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(line[0]);
            int k = int.Parse(line[1]);

            int[] a = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(f => int.Parse(f)).ToArray();

            Array.Sort(a);

            if(k == 0)
            {
                Console.WriteLine("-1");
                return;
            }

            if(k == a.Length)
            {
                Console.WriteLine(a[k - 1]);
                return;
            }

            if(a[k - 1] == a[k])
            {
                Console.WriteLine("-1");
                return;
            }
            Console.WriteLine(a[k - 1]);//
        }
    }
}
