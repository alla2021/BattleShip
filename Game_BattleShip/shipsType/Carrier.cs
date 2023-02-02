using Base;
using System;

namespace TypeShip
{
    class Carrier : BaseShip
    {
        public Carrier(string Name, int lenght) : base(Name, lenght)
        {
            shipType = "Carrier";
            Lenght = 4;
        }
        public override void showType()
        {
            Console.WriteLine(shipType);
        }
    }
}
