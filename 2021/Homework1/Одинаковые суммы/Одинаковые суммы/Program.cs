using System;
using System.Collections.Generic;
using System.Linq;

namespace Одинаковые_суммы
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int[] n = new int[k];
            int[] s = new int[k];
            int[][] a = new int[k][];

            Dictionary<int, MyStruct> availableNumbers = new Dictionary<int, MyStruct>(20000);

            for (int i = 0; i < k; i++)
            {
                n[i] = int.Parse(Console.ReadLine());
                a[i] = new int[n[i]];

                a[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(f => int.Parse(f)).ToArray();
                s[i] = a[i].Sum();

                HashSet<int> sequenceNumbers = new HashSet<int>();

                for (int j = 0; j < n[i]; j++)
                {
                    a[i][j] = s[i] - a[i][j];

                    bool availableNumbersContains = availableNumbers.ContainsKey(a[i][j]);
                    bool sequenceNumbersContains = sequenceNumbers.Contains(a[i][j]);

                    if (availableNumbersContains)
                    {
                        if(!sequenceNumbersContains)
                        {

                            MyStruct mystruct;
                            availableNumbers.TryGetValue(a[i][j], out mystruct);

                            Console.WriteLine("YES");
                            Console.WriteLine($"{i + 1} {j + 1}");
                            Console.WriteLine($"{mystruct.sequenceIndex + 1} {mystruct.elementIndex + 1}");
                            return;
                        }
                    }
                    else
                    {
                        availableNumbers.Add(a[i][j], new MyStruct { elementIndex = j, sequenceIndex = i });

                    }

                    if(!sequenceNumbersContains)
                        sequenceNumbers.Add(a[i][j]);
                }

            }
            Console.WriteLine("NO");
        }

        public struct MyStruct
        {
            public int elementIndex { get; set; }
            public int sequenceIndex { get; set; }
        }
    }
}
