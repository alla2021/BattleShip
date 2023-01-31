using Base;
using System;

namespace TypeShip
{
    class Cruiser : BaseShip
    {
        public Cruiser(string Name, int lenght) : base(Name, lenght)
        {
            ShipType = "Cruiser";
            Lenght = 2;
        }
    }
}
