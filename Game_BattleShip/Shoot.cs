using BaseCoord;
using System;

namespace BaseShoot
{
    public class Shoot
    {
        private Coordinate coord;
        private bool isHit = false;
        DateTime createObjTime;

        public Shoot(Coordinate coord, bool isHit)
        {
            this.coord = coord;
            this.isHit = isHit;
            createObjTime = DateTime.Now.ToLocalTime();
        }

        public Coordinate Coord { get; }
        public bool IsHit { get; }
    }
}
