using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerBalls
{
    public class Field
    {
        public int Width { get; }
        public int Length { get; }

        public Field(int width, int length)
        {
            this.Width = width;
            this.Length = length;
        }

        public int GetBallsCount(int radius)
        {
            int diameter = 2 * radius;
            int raws = this.Width / diameter;
            int columns = this.Length / diameter;

            return raws * columns;
        }
    }
}
