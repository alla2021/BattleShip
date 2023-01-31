using Base;
using System;

namespace TypeShip
{
    class Destroyer : BaseShip
    {
        public Destroyer(string Name, int lenght) : base(Name, lenght)
        {
            shipType = "Destroyer";
            Lenght = 1;
        }
    }
}
