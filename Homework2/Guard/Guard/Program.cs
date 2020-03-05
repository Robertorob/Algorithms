using System;
using System.Linq;
using System.Net.Sockets;

namespace Guard
{
    public class Sides
    {
        public int Left { get; set; }
        public int Right { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] massive1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(massive1[0]);
            int m = int.Parse(massive1[1]) + 2;

            Sides[] a = new Sides[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                a[i] = FillSides(line);
            }

            int sum = a[n - 1].Left;
            bool fromLeft = true;
            for (int i = n - 1; i > 0; i--)
            {
                if(a[i].Left != 0 && a[i - 1].Left == 0)
                {
                    if (a[i].Left + a[i].Right + 1 == m)//Case 1
                    {
                        Sides sides = FindZeros(a, i - 1);

                        if(sides == null)
                        {
                            break;
                        }

                        if(a[i].Left + sides.Left < a[i].Right + sides.Right)
                        {
                            sum += a[i].Left + 1;
                            fromLeft = true;
                        }
                        else
                        {
                            sum += a[i].Right + 1;
                            fromLeft = false;
                        }                       
                    }
                    else//Case 2
                    {
                        sum += m - a[i].Right - a[i].Left - 1;
                        int left1;
                        int right1;
                        if (fromLeft)
                        {
                            left1 = m - a[i].Right;
                            right1 = a[i].Right + 1; 
                        }
                        else
                        {
                            left1 = a[i].Left + 1;
                            right1 = m - a[i].Left;
 
                        }

                        Sides sides = FindZeros(a, i - 1);

                        if (sides == null)
                        {
                            break;
                        }

                        if (left1 + sides.Left < right1 + sides.Right)
                        {
                            sum += left1;
                            fromLeft = true;
                        }
                        else
                        {
                            sum += right1;
                            fromLeft = false;
                        }
                    }
                    continue;
                }

                if(a[i].Left == 0)
                {
                    if(a[i - 1].Left == 0)//Case 3
                    {
                        sum++;
                    }
                    else//Case 4
                    {
                        if (fromLeft)
                        {
                            sum += a[i - 1].Left + 1;
                        }
                        else
                        {
                            sum += a[i - 1].Right + 1;
                            fromLeft = false;
                        }
                    }
                    continue;
                }

               
                if (a[i].Left + a[i].Right + 1 == m)//Case 5
                {
                    int left = a[i].Left + a[i - 1].Left + 1;
                    int right = a[i].Right + a[i - 1].Right + 1;
                    if (left <= right)
                    {
                        sum += left;
                        fromLeft = true;
                    }
                    else
                    {
                        sum += right;
                        fromLeft = false;
                    }
                    continue;
                }
                else// Case 6
                {
                    if (fromLeft)
                    {
                        sum += m - a[i].Right - a[i].Left - 1;
                        int leftL = a[i - 1].Left + (m - a[i].Right);
                        int rightR = a[i - 1].Right + a[i].Right + 1;
                        if(leftL > rightR)
                        {
                            sum += rightR;
                            fromLeft = false;
                        }
                        else
                        {
                            sum += leftL;
                            fromLeft = true;
                        }
                    }
                    else
                    {
                        sum += m - a[i].Right - a[i].Left - 1;
                        int leftL = a[i - 1].Left + a[i].Left + 1;
                        int rightR = a[i - 1].Right + (m - a[i].Left);
                        if (leftL > rightR)
                        {
                            sum += rightR;
                            fromLeft = false;
                        }
                        else
                        {
                            sum += leftL;
                            fromLeft = true;
                        }
                    }
                }              
            }

            if (a[0].Left + a[0].Right + 1 != m && a[0].Left != 0)// Case 7
            {
                sum += m - a[0].Right - a[0].Left - 1;
            }

            var asdf = FindZeros(a, a.Length - 1);
            if (asdf == null)
                sum = 0;

            //bool zeros = a[0].Left == 0;
            //if (zeros)
            //{
            //    int j = 0;
            //    while (zeros)
            //    {
            //        sum--;
            //        j++;
            //        if (j == a.Length)
            //            break;
            //        zeros = a[j].Left == 0;
            //    }
            //    if (j != n)
            //    {
            //        if (fromLeft)
            //        {
            //            sum -= a[j].Left;
            //        }
            //        else
            //        {
            //            sum -= a[j].Right;
            //        } 
            //    }
            //}  

            if (sum < 0)
            {
                sum = 0;
            }

            Console.WriteLine(sum);
        }

        public static Sides FindZeros(Sides[] a, int index) 
        {
            for (int i = index; i >= 0; i--)
            {
                if(a[i].Left != 0)
                {
                    return new Sides { Left = a[i].Left, Right = a[i].Right };
                }
            }
            return null;
        }

        public static Sides FillSides(char[] array)
        {
            Sides sides = new Sides();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    sides.Left = i;
                    break;
                }      
            }

            array = array.Reverse().ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    sides.Right = i;
                    break;
                }
            }
            return sides;
        }
    }
}
