using Base;
using System;

namespace TypeShip
{
    class Cruiser : BaseShip
    {
        public Cruiser(string Name, int lenght) : base(Name, lenght)
        {
            shipType = "Cruiser";
            Lenght = 2;
        }
        public override void showType()
        {
            Console.WriteLine(shipType);
        }
    }
}
