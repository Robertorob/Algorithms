using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string largestNumber(List<int> A)
        {
            var list = A.Select(f => f.ToString()).ToList();

            list = list.OrderByDescending(f => f, new MyComparer()).ToList();

            var strBuilder = new StringBuilder();

            foreach (var f in list)
            {
                strBuilder.Append(f);
            }

            return strBuilder.ToString();
        }

        public class MyComparer : IComparer<Object>
        {
            public int Compare(Object x, object y)
            {
                var xy = stringA.ToString().ToCharArray();
                var yx = y.ToString().ToCharArray();

                if (xy.Length == yx.Length)
                {
                    return stringA.ToString().CompareTo(y.ToString());
                }

                for (int i = 0; i < length; i++)
                {
                    xy[i] > 
                }
            }
        }
    }
}
