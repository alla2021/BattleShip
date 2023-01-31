using System;
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
            engine.genereteaFleetOfShipsFirstPlayer();
           
            engine.genereteaFleetOfShipsSecondPlayer();

            engine.printPlayersBoards();

            
        }
    }
}
