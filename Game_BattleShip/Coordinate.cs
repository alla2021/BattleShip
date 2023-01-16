namespace Game_BattleShip
{
    public class Coordinate
    {
        private int x;
        private int y;
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinate() { }
        public int getX
        {
            get { return this.x; }
        }
        public int getY
        {
            get { return this.y; }
        }
    }
}