

namespace Game_BattleShip
{
    class Destroyer : BaseShip
    {
        public Destroyer(string Name) : base(Name)
        {
            shipType = "Destroyer";
            Lenght = 1;
        }
    }
    class Cruiser : BaseShip
    {
        public Cruiser(string Name) : base(Name)
        {
            ShipType = "Cruiser";
            Lenght = 2;
        }
    }

    class Battleship : BaseShip
    {
        public Battleship(string Name) : base(Name)
        {
            ShipType = "Battleship";
            Lenght = 3;
        }
    }

    class Carrier : BaseShip
    {
        public Carrier(string Name) : base(Name)
        {
            ShipType = "Carrier";
            Lenght = 4;
        }
    }
}
