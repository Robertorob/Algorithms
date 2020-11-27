using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Сбор_посылок
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            StringBuilder output = new StringBuilder();

            while(count > 0)
            {
                int n = int.Parse(Console.ReadLine());

                int[,] a = new int[n, n];

                List<MyStruct> list = new List<MyStruct>();

                for (int i = 0; i < n; i++)
                {
                    var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int x = int.Parse(line[0]);
                    int y = int.Parse(line[1]);

                    list.Add(new MyStruct { x = x, y = y });
                }
                
                list = list.OrderBy(f => f, new MyComparer()).ToList();

                int cX = 0, cY = 0;
                int result = 0;

                StringBuilder str = new StringBuilder();

                bool flag = false;

                foreach (var item in list)
                {
                    int x = item.x;
                    int y = item.y;

                    if(x < cX || y < cY)
                    {
                        output.AppendLine("NO");
                        flag = true;
                    }

                    int right = x - cX;
                    int up = y - cY;

                    for (int i = 0; i < right; i++)
                    {
                        str.Append("R");
                    }
                    for (int i = 0; i < up; i++)
                    {
                        str.Append("U");
                    }

                    result = (x - cX) + (y - cY);
                    cX = x;
                    cY = y;
                }
                count--;

                if (flag)
                    continue;

                output.AppendLine("YES");
                output.AppendLine(str.ToString());

            }

            Console.WriteLine(output.ToString());
        }

        public struct MyStruct
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        public class MyComparer : IComparer<Object>
        {
            public int Compare(Object x, object y)
            {
                var xTuple = (MyStruct)x;
                var yTuple = (MyStruct)y;

                if(xTuple.x != yTuple.x)
                {
                    return xTuple.x.CompareTo(yTuple.x);
                }
                return xTuple.y.CompareTo(yTuple.y);
            }
        }
    }
}
