using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_BattleShip
{
    enum Direction
    {
        North = 0,
        West,
        South,
        East
    }
    public class Engine
    {
        private List<BaseShip> baseShipsListFirstPlayer;
        private List<Shoot> baseShootListFirstPlayer;
        private List<BaseShip> baseShipsListSecondPlayer;
        private List<Shoot> baseShootListSecondPlayer;
        private PrintBoards print;
        private Random random;

        public Engine()
        {
            this.baseShipsListFirstPlayer = new List<BaseShip>();
            this.baseShootListFirstPlayer = new List<Shoot>();
            this.baseShipsListSecondPlayer = new List<BaseShip>();
            this.baseShootListSecondPlayer = new List<Shoot>();
            print = new PrintBoards();
        }

        public void addShootFirstPlayer(Shoot shoot)
        {
            this.baseShootListFirstPlayer.Add(shoot);
        }

        public void addShootSecondPlayer(Shoot shoot)
        {
            this.baseShootListSecondPlayer.Add(shoot);
        }

        public void addShipFirstPlayer(BaseShip baseShip)
        {
            this.baseShipsListFirstPlayer.Add(baseShip);
        }

        public void addShipSecondPlayer(BaseShip baseShip)
        {
            this.baseShipsListSecondPlayer.Add(baseShip);
        }
        public void printPlayersBoards()
        {
            this.print.printLeftField(this.baseShipsListFirstPlayer);
            this.print.printRightField(this.baseShootListFirstPlayer);
        }


    }
}
