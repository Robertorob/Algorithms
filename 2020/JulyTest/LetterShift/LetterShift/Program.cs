using System;

namespace LetterShift
{
    class Program
    {
        static void Main(string[] args)
        {
            //char a = 'a';
            //char b = 'b';
            //char c = 'c';
            //char z = 'z';

            //Console.WriteLine(Shift(b));

            var line = Console.ReadLine().ToCharArray();

            bool flag = false;
            for (int i = 0; i < line.Length; i++)
            {
                if(line[i] != 'a')
                {
                    flag = true;
                    while (i < line.Length && line[i] != 'a')
                    {
                        line[i] = Shift(line[i]);
                        i++;
                    }
                    break;
                }
            }

            if (!flag)
            {
                line[line.Length - 1] = 'z';
                Console.WriteLine(new string(line));
                return;
            }

            Console.WriteLine(new string(line));
        }

        public static char Shift(char x)
        {
            int code = x - 1;
            if (code < 97)
                code = 122;
            return (char)code;
        }
    }
}
