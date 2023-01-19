using Base;

namespace TypeShip
{
    class Carrier : BaseShip
    {
        public Carrier(string Name) : base(Name)
        {
            ShipType = "Carrier";
            Lenght = 4;
        }
    }
}
