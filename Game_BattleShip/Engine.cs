using System;
using System.Collections.Generic;
using Base;
using BaseCoord;
using BaseShoot;
using TypeShip;

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
        private bool checkShipPosition(Coordinate firstCoord, int shipType, Direction direction, List<BaseShip> list)
        {
            if (shipType == 1) // алгоритм тільки для однопалубних  кораблів
            {
                foreach (BaseShip item in list)
                {
                    foreach (Coordinate coord in item.getCoordinates())
                    {
                        if (coord.getX == firstCoord.getX && coord.getY == firstCoord.getY)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void generateShip(string name, int type = 1)
        {
            BaseShip baseShip = null;
            bool isEmpty = true;
            do
            {
                Coordinate firstCoord = new Coordinate(this.random.Next(0, 10), this.random.Next(0, 10)); // генеруємо випадкову координату
                isEmpty = checkShipPosition(firstCoord, type, Direction.North, baseShipsListFirstPlayer); // перевіряємо чи вільна вона
                if (isEmpty) // якщо вільна
                {
                    baseShip = new Destroyer(name); // то створюємо корабель
                    baseShip.addCoord(firstCoord);

                    this.addShipFirstPlayer(baseShip); // і поміщаємо його в масив
                }
            } while (!isEmpty); // якщо координати зайнята ідемо на нову ітерацію
        }

    }
}
