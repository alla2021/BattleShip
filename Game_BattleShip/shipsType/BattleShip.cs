using Base;


namespace TypeShip
{
    class Battleship : BaseShip
    {
        public Battleship(string Name) : base(Name)
        {
            ShipType = "Battleship";
            Lenght = 3;
        }
    }
}
