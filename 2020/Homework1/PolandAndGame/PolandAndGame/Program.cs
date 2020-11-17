using System;
using System.Collections.Generic;

namespace PolandAndGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string[] mass1 = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(mass1[0]);
            int m = int.Parse(mass1[1]);

            string[] polshar = new string[n];
            Dictionary<string, string> polsharSet = new Dictionary<string, string>(n);
            string[] vragoshar = new string[m];
            Dictionary<string, string> vragosharSet = new Dictionary<string, string>(m);

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                polshar[i] = line;
                polsharSet.Add(line, null);
            }

            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();
                vragoshar[i] = line;
                vragosharSet.Add(line, null);
            }

            bool vragosharDistinct = false;
            bool polsharDistinct = false;

            for (int i = 0; i < n + m; i++)
            {
                if(polsharDistinct && vragosharDistinct)
                {
                    break;
                }

                if(i % 2 == 0)
                {
                    if (polsharDistinct)
                    {
                        continue;
                    }

                    bool flag = false;
                    KeyValuePair<string, string> word = new KeyValuePair<string, string>();
                    foreach (var polsharWord in polsharSet)
                    {
                        if (vragosharSet.Remove(polsharWord.Key))
                        {
                            word = polsharWord;
                            flag = true;
                            break;
                        }
                            
                    }

                    if (!flag)
                    {
                        polsharDistinct = true;                     
                    }
                }
                else
                {
                    if (vragosharDistinct)
                    {
                        continue;
                    }

                    bool flag = false;
                    KeyValuePair<string, string> word = new KeyValuePair<string, string>();
                    foreach (var vragosharWord in vragosharSet)
                    {
                        if (polsharSet.Remove(vragosharWord.Key))
                        {
                            word = vragosharWord;
                            flag = true;
                            break;
                        }

                    }
                    if (!flag)
                    {
                        vragosharDistinct = true;
                    }

                }
            }

            Console.WriteLine(polsharSet.Count > vragosharSet.Count ? "YES" : "NO");
        }
    }
}
