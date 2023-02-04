using System;

namespace BaseCoord
{
    public class Coordinate
    {
        private const int rows = 9;
        private const int column = 9;

        public Coordinate(int x, int y)
        {
            if (X < 0 || X >= rows || Y < 0 || Y >= column)
            {
                throw new ArgumentException($"X and Y  '({X}, {Y})' should be in the range 0 to 9");
            }
            this.X = x;
            this.Y = y;
        }

        public Coordinate() { }

        public int X { get; set; }

        public int Y { get; set; }
    }
}