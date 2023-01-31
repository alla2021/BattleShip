using System;

namespace BaseCoord
{
    public class Coordinate
    {
        private int x;
        private int y;

        private const int rows = 9;
        private const int column = 9;

        public Coordinate(int x, int y)
        {
            if (X < 0 || X >= rows || Y < 0 || Y >= column)
            {
                throw new ArgumentException($"X and Y  '({X}, {Y})' should be in the range 0 to 9");
            }
            this.x = x;
            this.y = y;
        }

        public Coordinate() { }

        public int X
        {
            get => this.x; 
            set => this.x = value; 

        }
        public int Y
        {
            get => this.y; 
            set => this.y = value; 
        }
    }
}