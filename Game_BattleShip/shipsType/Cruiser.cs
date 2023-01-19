using Base;
using System;

namespace TypeShip
{
    class Cruiser : BaseShip
    {
        public Cruiser(string Name) : base(Name)
        {
            ShipType = "Cruiser";
            Lenght = 2;
        }
    }
}
