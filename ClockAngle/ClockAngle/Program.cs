using System;

namespace ClockAngle
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = 1;
            int minutes = 56;

            Console.WriteLine(GetAngle(hours, minutes));

            Console.ReadKey();
        }

        public static double GetAngle(int hours, int minutes)
        {
            if(hours > 11 || minutes >= 60)
            {
                throw new FormatException("Wrong format");
            }

            double hourMinutes = (double)hours * 5 + ((double)minutes / 60) * 5;
            double angleMinutes = Math.Abs(hourMinutes - minutes);
            return (angleMinutes / 60) * 360;
        }
    }
}
