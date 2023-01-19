using Base;
using System;

namespace TypeShip
{
    class Destroyer : BaseShip
    {
        public Destroyer(string Name) : base(Name)
        {
            shipType = "Destroyer";
            Lenght = 1;
        }
    }
}
