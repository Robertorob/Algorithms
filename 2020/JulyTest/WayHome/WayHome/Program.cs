using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace WayHome
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var line = Console.ReadLine().Split(new char[] { ' ' });

        //    int n = int.Parse( line[0]);
        //    int d = int.Parse( line[1]);

        //    var s = Console.ReadLine().ToCharArray();

        //    int shift = 0;
        //    int count = 0;
        //    for (int i = 0; i < s.Length; i = i + shift)
        //    {
        //        shift = 0;
        //        for (int j = 1; j <= d; j++)
        //        {
        //            if(i + j >= s.Length)
        //            {
        //                if(j != 1)
        //                    count++;
        //                Console.WriteLine(count);
        //                return;
        //            }
        //            if(s[i + j] == '1')
        //            {
        //                shift = j;
        //            }
        //        }
        //        if(shift == 0)
        //        {
        //            Console.WriteLine("-1");
        //            return;
        //        }
        //        count++;
        //    }

        //    Console.WriteLine(count);
        //}



        //    static void Main(string[] args)
        //    {
        //        int n = int.Parse(Console.ReadLine());

        //        if(n == 1)
        //        {
        //            Console.WriteLine("1");
        //            return;
        //        }

        //        StringBuilder str = new StringBuilder();
        //        for (int i = 1; i <= n; i++)
        //        {
        //            str.Append(i.ToString());
        //        }

        //        PrintAllPermutations(str.ToString());
        //    }

        //    public static void PrintAllPermutations(string input)
        //    {
        //        if (string.IsNullOrEmpty(input))
        //        {
        //            Console.WriteLine("String is empty");
        //            return;
        //        }

        //        char[] permutation = input.ToArray();
        //        Array.Sort(permutation);

        //        PrintPermutation(permutation);

        //        while (NextPermutation(permutation))
        //        {
        //            PrintPermutation(permutation);
        //        }
        //    }

        //    public static bool NextPermutation(char[] permutation)
        //    {
        //        // 123 654 -> 124 653 -> 124 356
        //        // Going through all elements from right and trying to find an element where sequence begins to descend (descendCharIndex).
        //        int descendCharIndex = 0;
        //        for (int i = permutation.Length - 1; i > 0; i--)
        //        {
        //            if (permutation[i] > permutation[i - 1])
        //            {
        //                descendCharIndex = i - 1;
        //                break;
        //            }

        //            // Assign index to -1, if there is no permutations left.
        //            if (i - 1 == 0)
        //            {
        //                return false;
        //            }
        //        }

        //        // Going through all elements from right and trying to find the next character after the sequence-begins-to-descend character.
        //        int nextCharIndex = 0;
        //        for (int i = permutation.Length - 1; i >= 0; i--)
        //        {
        //            if (permutation[i] > permutation[descendCharIndex])
        //            {
        //                nextCharIndex = i;
        //                break;
        //            }
        //        }

        //        Swap(permutation, descendCharIndex, nextCharIndex);
        //        Array.Reverse(permutation, descendCharIndex + 1, permutation.Length - descendCharIndex - 1);

        //        return true;
        //    }

        //    public static void Swap(char[] array, int x, int y)
        //    {
        //        char z = array[x];
        //        array[x] = array[y];
        //        array[y] = z;
        //    }

        //    public static void PrintPermutation(char[] permutation)
        //    {
        //        Console.WriteLine(string.Join(" ", permutation));
        //    }

        public static bool[,] Checked { get; set; }

        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split(new char[] { ' ' });

            int h = int.Parse(line1[0]);
            int w = int.Parse(line1[1]);

            Checked = new bool[h, w];

            char[,] m = new char[h, w];

            for (int i = 0; i < h; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < w; j++)
                {
                    m[i, j] = line[j];
                }
            }

            bool flag = false;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if(i > 0 && j > 0 && j < w - 1 && i < h - 1 && m[i,j] == '*' && m[i - 1,j] == '*' && m[i,j-1] == '*' && m[i+1, j] == '*' && m[i, j + 1] == '*')
                    {
                        SetCenter(m, i, j, h, w);
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if(!Checked[i,j] && m[i,j] == '*')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");


        }

        public static void SetCenter(char[,] m, int indexI, int indexJ, int h, int w)
        {
            int i = 1;
            Checked[indexI, indexJ] = true;
            while (indexJ + i < w)
            {
                if(m[indexI, indexJ + i] == '*')
                {
                    Checked[indexI, indexJ + i] = true;
                    i++;
                }
                else
                {
                    break;
                }
            }

            i = 1;
            while (indexJ - i >= 0)
            {
                if (m[indexI, indexJ - i] == '*')
                {
                    Checked[indexI, indexJ - i] = true;
                    i++;
                }
                else
                {
                    break;
                }
            }

            i = 1;
            while (indexI - i >= 0)
            {
                if (m[indexI - i, indexJ] == '*')
                {
                    Checked[indexI - i, indexJ] = true;
                    i++;
                }
                else
                {
                    break;
                }
            }

            i = 1;
            while (indexI + i < h)
            {
                if (m[indexI + i, indexJ] == '*')
                {
                    Checked[indexI + i, indexJ] = true;
                    i++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
