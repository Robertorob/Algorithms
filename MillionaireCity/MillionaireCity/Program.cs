using System;

namespace MillionaireCity
{
    public class Village : IComparable
    {
        public int PeopleAmount { get; set; }
        public double Radius { get; set; }
        public int PeopleSum { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Village otherVillage = obj as Village;
            if (otherVillage != null)
                return this.Radius.CompareTo(otherVillage.Radius);
            else
                throw new ArgumentException("Object is not a Village");
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

            Village[] villages = new Village[n];

            for (int i = 0; i < n; i++)
            {
                string line2 = Console.ReadLine();
                string[] mass2 = line2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int xi = int.Parse(mass2[0]);
                int yi = int.Parse(mass2[1]);

                villages[i] = new Village();
                villages[i].Radius = Math.Sqrt(xi * xi + yi * yi);
                villages[i].PeopleAmount = int.Parse(mass2[2]);
            }

            Array.Sort(villages);

            villages[0].PeopleSum = villages[0].PeopleAmount;
            for (int i = 0; i < villages.Length - 1; i++)
            {
                villages[i + 1].PeopleSum = villages[i + 1].PeopleAmount + villages[i].PeopleSum;
            }

            Console.WriteLine(BinarySearch(villages, 1000000 - s));
        }

        public static double BinarySearch(Village[] mass, int value)
        {
            int l = -1, r = mass.Length - 1;

            if (mass[mass.Length - 1].PeopleSum < value)
                return -1;

            if (mass[mass.Length - 1].PeopleSum == value)
                return mass[mass.Length - 1].Radius;

            if (mass[0].PeopleSum >= value)
                return mass[0].Radius;

            while (l < r + 1)
            {
                int m = (r + l) / 2;

                if (mass[m].PeopleSum == value)
                    return mass[m].Radius;

                if (mass[m].PeopleSum < value && mass[m + 1].PeopleSum > value)
                    return mass[m + 1].Radius;

                if (mass[m].PeopleSum < value)
                    l = m;
                else
                    r = m;
            }
            return mass[r + 1].Radius;
        }
    }
}
