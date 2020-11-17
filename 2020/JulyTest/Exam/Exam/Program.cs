using System;
using System.Collections.Specialized;
using System.Text;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            // StringBuilder str = new StringBuilder(input);

            var f = input.ToCharArray();
            int count = 0;
            int state = 0;
            int maxCount = 0;
            for (int i = 0; i < f.Length; i++)
            {
                if(f[i] == 'a' && (state == 0 || state == 1))
                {
                    state = 1;
                    count++;
                    continue;
                }
                if(f[i] == 'b' && (state == 1 || state == 2))
                {
                    state = 2;
                    count++;
                    continue;
                }
                if(f[i] == 'a' && (state == 2 || state == 3))
                {
                    state = 3;
                    count++;
                    continue;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                }
                state = 0;
                count = 0;
            }

            if (count > maxCount)
            {
                maxCount = count;
            }

            int count2 = 0;
            state = 0;
            int maxCount2 = 0;
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i] == 'b' && (state == 0 || state == 1))
                {
                    state = 1;
                    count2++;
                    continue;
                }
                if (f[i] == 'a' && (state == 1 || state == 2))
                {
                    state = 2;
                    count2++;
                    continue;
                }
                if(count2 > maxCount2)
                {
                    maxCount2 = count2;
                }
                state = 0;
                count2 = 0;
            }
            if (count2 > maxCount2)
            {
                maxCount2 = count2;
            }

            Console.WriteLine(Math.Max(maxCount, maxCount2));
        }

        public static bool IsAnagram(string a, string b){
            var arrayA = a.ToCharArray();
            //var arrayB = b.ToCharArray();
        
            if(a.Length != b.Length){
                return false;
            }

                StringBuilder str = new StringBuilder(b);
        
            for(int i = 0;i<arrayA.Length;i++){
                b.Replace(arrayA[i].ToString(), "");
            }
        
            return b == "";
        }
    }
}
