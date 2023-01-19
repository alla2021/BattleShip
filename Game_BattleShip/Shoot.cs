using BaseCoord;

namespace BaseShoot
{
    public class Shoot
    {
        private Coordinate coord;
        private bool isHit = false;

        public Shoot(Coordinate coord, bool isHit)
        {
            this.coord = coord;
            this.isHit = isHit;
        }
        public Coordinate Coord { get; }
        public bool IsHit { get; }
    }
}
