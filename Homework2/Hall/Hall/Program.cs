using System;
using System.Linq;
using System.Numerics;

namespace Hall
{
    class Program
    {
        private const long mod = 1000000009;
        static void Main(string[] args)
        {
            long[] mass = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(f => long.Parse(f)).ToArray();
            long n = mass[0];
            long a = mass[1];
            long b = mass[2];

            if(a + 3 * b < n)
            {
                Console.WriteLine(0);
                return;
            }

            if (a == 0)
            {
                if (n % 3 == 0)
                    Console.WriteLine(1);
                else 
                    Console.WriteLine(0);
                return;
            }

            if (b == 0)
            {
                Console.WriteLine(1);
                return;
            }

            // Console.WriteLine(Choose(n, a, b) % mod); this approach works fine with n = 50 and it also shows permutations

            /* Next approach is to just find the count of permutations */

            long count = 0;
            long originalA = a;
            long originalB = b;
            long sum;
            for (long i = 0; i <= a; i++)
            {
                for (long j = 0; j <= b; j++)
                {
                    sum = i + 3 * j;
                    if(sum == n)
                    {
                        if (i == 0 || j == 0)
                        {
                            count++;
                            i++;
                            continue;
                        }

                        long p = P(i, j);

                        if(p <= 0)
                        {

                        }

                        count += p;
                    }
                }
            }

            Console.WriteLine(count % mod);
        }

        public static long P(long a, long b)
        {
            BigInteger c = a + b;
            if(a < b)
            {
                long temp = a;
                a = b;
                b = temp;
            }

            BigInteger g = c - 1;
            for (long i = 0; i < b - 1; i++)
            {
                c = c * g;
                g--;
            }
            for (long i = 0; i < b; i++)
            {
                c /= (i + 1);
            }
            c = c % mod;
            return (long)c;
        }

        public static long FactorialMod(long value)
        {
            long result = 1;
            for (long i = 2; i <= value; i++)
            {
                result = i * result;
            }
            return result;
        }

        public static long Choose(long n, long a, long b)
        {
            if (n == 0)
                return 1;

            if (n < 0)
                return 0;

            bool aGreaterThanZero = a > 0;
            bool bGreaterThanZero = b > 0;

            if (n == 1 && aGreaterThanZero)
                return 1;

            if(n == 2)
            {
                if (a > 1)
                    return 1;
                return 0;
            }

            

            if (n == 3)
            {
                bool aCond = a >= 3;
                bool bCond = b >= 1;
                if (aCond && bCond)
                    return 2;
                if (aCond || bCond)
                    return 1;
            }

            if(aGreaterThanZero && bGreaterThanZero)
            {
                return (Choose(n - 1, a - 1, b) + Choose(n - 3, a, b - 1)) % mod;
            }
                

            if (aGreaterThanZero)
            {
                if (a >= n)
                    return 1;
                return 0;
            }

            if (bGreaterThanZero)
            {
                if (n % 3 == 0)
                    return 1;
                return 0;
            }
                

            return 0;
        }
    }
}
