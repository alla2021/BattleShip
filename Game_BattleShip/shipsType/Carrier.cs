using Base;

namespace TypeShip
{
    class Carrier : BaseShip
    {
        public Carrier(string Name, int lenght) : base(Name, lenght)
        {
            ShipType = "Carrier";
            Lenght = 4;
        }
    }
}
