using Base;


namespace TypeShip
{
    class Battleship : BaseShip
    {
        public Battleship(string Name, int lenght) : base(Name, lenght)
        {
            ShipType = "Battleship";
            Lenght = 3;
        }
    }
}
