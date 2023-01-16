using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseShip obj = new Destroyer("hood");
            obj.addCoord(new Coordinate(1, 2)).addCoord(new Coordinate(1, 3));
            Engine engine = new Engine();
            engine.printPlayersBoards();

            engine.addShipFirstPlayer(new Destroyer("1"));
            engine.addShipFirstPlayer(new Destroyer("2"));
            engine.addShipFirstPlayer(new Destroyer("3"));
            engine.addShipFirstPlayer(new Destroyer("4"));
            engine.addShipFirstPlayer(new Cruiser("5"));
            engine.addShipFirstPlayer(new Cruiser("6"));
            engine.addShipFirstPlayer(new Cruiser("7"));
            engine.addShipFirstPlayer(new Battleship("8"));
            engine.addShipFirstPlayer(new Battleship("9"));
            engine.addShipFirstPlayer(new Carrier("10"));


        }
    }
}
