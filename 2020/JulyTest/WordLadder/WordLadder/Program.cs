using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "hit";
            string b = "som";

            List<string> c = new List<string>
            {
                "hot", "git", "hil", "got", "dot", "dog", "lot", "log", "lom"
            };

            Console.WriteLine(Solve(a, b, c));
        }

        public static int Solve(string A, string B, List<string> C)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var item in C)
            {
                set.Add(item);
            }

            Queue<string> q = new Queue<string>();
            q.Enqueue(A);

            int distance = 0;

            while (q.Count > 0)
            {

                int count = q.Count;
                distance++;

                for (int k = 0; k < count; k++)
                {
                    string word = q.Dequeue();
                    var a = word.ToCharArray();

                    for (int i = 0; i < a.Length; i++)
                    {
                        for (int j = 0; j < 26; j++)
                        {
                            if (a[i] == 'a' + j)
                                continue;
                            else
                            {
                                char temp = a[i];
                                a[i] = (char)('a' + j);
                                var add = new string(a);

                                if (add == B)
                                {
                                    distance++;
                                    return distance;
                                }

                                if (set.Contains(add))
                                {
                                    q.Enqueue(add);
                                    set.Remove(add);
                                }
                                a[i] = temp;
                            }
                        }
                    } 
                }
            }

            return -1;
        }
    }
}
