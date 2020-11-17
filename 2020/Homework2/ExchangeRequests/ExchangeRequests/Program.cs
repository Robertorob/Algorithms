using System;
using System.Linq;

namespace ExchangeRequests
{
    public class Request : IComparable
    {
        public char d { get; set; }//direction
        public int p { get; set; }//price
        public int q { get; set; }//quantity

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Request otherRequest = obj as Request;
            if (otherRequest != null)
                return this.p.CompareTo(otherRequest.p);
            else
                throw new ArgumentException("Object is not a Request");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string[] mass1 = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(mass1[0]);
            int s = int.Parse(mass1[1]);

            Request[] requests = new Request[n];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] mass = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                requests[i] = new Request();
                requests[i].d = mass[0].ToCharArray()[0];
                requests[i].p = int.Parse(mass[1]);
                requests[i].q = int.Parse(mass[2]);
            }

            var asdf = requests.AsQueryable();
            var buy = asdf
                .Where(f => f.d == 'B')
                .GroupBy(f => new { f.p })
                .Select(f => new Request { p = f.Key.p, q = f.Sum(sum => sum.q) })
                .ToArray();
            var sell = asdf
                .Where(f => f.d == 'S')
                .GroupBy(f => new { f.p })
                .Select(f => new Request { p = f.Key.p, q = f.Sum(sum => sum.q) })
                .ToArray();

            Array.Sort(buy, new Comparison<Request>(
                            (i1, i2) => i2.CompareTo(i1)));

            Array.Sort(sell, new Comparison<Request>(
                            (i1, i2) => i2.CompareTo(i1)));

            int sellCount = sell.Count();
            sellCount = s > sellCount ? sellCount : s;
            for (int i = sell.Count() - sellCount; i < sell.Count(); i++)
            {
                Console.WriteLine("S " + sell[i].p + " " + sell[i].q);
            }

            int buyCount = buy.Count();
            buyCount = s > buyCount ? buyCount : s;
            for (int i = 0; i < buyCount; i++)
            {
                Console.WriteLine("B " + buy[i].p + " " + buy[i].q);
            }
        }
    }
}
