using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 17;
            int p = 3;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i + ": " + GetFibonacciNumber(i, p));
            }           
        }

        // Найти n-ое число фибоначчи по модулю p
        // Решение: находим повторяющуюся пару - это начало нового цикла. Далее находим индекс начала цикла. 
        // 
        /*
         *  0:      n = 1       1      (1)   
            1:      n = 2       1      (1)   
            2:      n = 3       2       2
            3:      n = 4       3       0
            4:      n = 5       5       2
            5:      n = 6       8       2
            6:      n = 7       13      1
            7:      n = 8       21      0
            8:      n = 9       34     (1)   
            9:      n = 10      55     (1)   
            10:     n = 11      89      2
            11:     n = 12      144     0
            12:     n = 13      233     2
            13:     n = 14      377     2
            14:     n = 15      610     1
            15:     n = 16      987     0
			16:		n = 17      1597    1
         */
        public static int GetFibonacciNumber(int n, int p)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;

            int[] cicle = new int[p * p + 2];

            int n1 = 1;
            int n2 = 1;
            int n3;

            cicle[0] = n1;
            cicle[1] = n2;

            int index = 2;
            while (true)
            {                
                n3 = (n1 + n2) % p;

                if (index == n - 1)
                    return n3;

                cicle[index] = n3;

                n1 = n2;
                n2 = n3;

                if (n1 == 1 && n2 == 1)
                {
                    break;
                }

                index++;
            }

            index--;
            int resultIndex = (n - 1) % index;
            return cicle[resultIndex];
        }
    }
}
