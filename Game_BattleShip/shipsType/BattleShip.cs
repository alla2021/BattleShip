using Base;
using System;

namespace TypeShip
{
    class Battleship : BaseShip
    {
        public Battleship(string Name, int lenght) : base(Name, lenght)
        {
            shipType = "Battleship";
            Lenght = 3;
        }
        public override void showType()
        {
            Console.WriteLine(shipType);
        }


    }
}
