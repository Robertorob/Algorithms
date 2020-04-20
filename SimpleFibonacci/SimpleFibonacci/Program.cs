using System;

namespace SimpleFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;

            Console.WriteLine(Fibonacci(n));
            Console.WriteLine(FibonacciRecursive(n));
            Console.ReadKey();
        }

        public static int Fibonacci(int n)
        {
            if(n == 0)
                return 0;
            if (n == 1)
                return 1;

            int f1 = 0;
            int f2 = 1;
            int f3 = 0;
            for (int i = 0; i < n - 1; i++)
            {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
            }

            return f3;
        }

        public static int FibonacciRecursive(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }
    }
}
