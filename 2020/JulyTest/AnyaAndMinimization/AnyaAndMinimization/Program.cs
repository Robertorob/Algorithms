﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            var line1 = Console.ReadLine().Split(new char[] { ' ' });
            var line2 = Console.ReadLine();
            long n = long.Parse(line1[0]);
            long k = long.Parse(line1[1]);


            if (k == 0)
            {
                Console.WriteLine(line2);
                return;
            }

            if (n == 1 && k > 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (n == 1 && k == 0)
            {
                Console.WriteLine(line2);
                return;
            }


            char[] result = line2.ToCharArray();

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    if (result[i] != '1' && k > 0)
                    {
                        result[i] = '1';
                        k--;
                    }
                }
                else
                {
                    if (result[i] == 0)
                        continue;
                    if (k > 0 && result[i] != '0')
                    {
                        result[i] = '0';
                        k--;
                    }
                }
            }

            Console.WriteLine(new string(result));
        }
    }
}
