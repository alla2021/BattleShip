using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Base;
using BaseCoord;
using BaseShoot;
using TypeShip;

namespace Game_BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            
            List<string> list = new List<string>()
            {
            "Fiona", "Arbroath", "Auricula", "Wren", "Ganges", "Vanity", "Latona", "Consort", "Gypsy","The Marianne",  "Sevenoaks", "Exmouth", "Triad", "Tigris", "Crofton", "The Sprightly", "Port Arthur", "Clorinde", "The Fastnet", "The Magdalen"
            };

            engine.genereteaFleetOfShipsFirstPlayer(list);     
            engine.genereteaFleetOfShipsSecondPlayer(list);

            engine.printPlayersBoards();

            
        }
    }
}
