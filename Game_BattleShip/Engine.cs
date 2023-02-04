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
        East,
        South,
        West
    }

    public class Engine
    {
        private Random random;
        private List<BaseShip> baseShipsListFirstPlayer;
        private List<Shoot> baseShootListFirstPlayer;
        private List<BaseShip> baseShipsListSecondPlayer;
        private List<Shoot> baseShootListSecondPlayer;
        private PrintBoards print;

        public Engine()
        {
            random = new Random();
            this.baseShipsListFirstPlayer = new List<BaseShip>();
            this.baseShootListFirstPlayer = new List<Shoot>();
            this.baseShipsListSecondPlayer = new List<BaseShip>();
            this.baseShootListSecondPlayer = new List<Shoot>();
            print = new PrintBoards();
        }
        // постріли------------------------------------
        public void addShootFirstPlayer(Shoot shoot)
        {
            this.baseShootListFirstPlayer.Add(shoot);
        }

        public void addShootSecondPlayer(Shoot shoot)
        {
            this.baseShootListSecondPlayer.Add(shoot);
        }
        //------------------------------------------------
        private Coordinate createCoord(Direction direction, int x, int y)
        {
            switch (direction)
            {
                case Direction.North:
                    {
                        ++y; 
                    }
                    break;
                case Direction.East:
                    {
                        ++x; 
                    }
                    break;
                case Direction.South:
                    { 
                        --y; 
                    }
                    break;
                case Direction.West:
                    { 
                        --x; 
                    }
                    break;
            }
            return new Coordinate(x,y);
        }
        //--------------------------------------------------------------------------------------------------------

        private void addShipFirstPlayer(Coordinate firstCoord, int lenght, Direction randDirection, BaseShip baseShip)
        {
            if (lenght == 1)
            {
                baseShip.addCoord(firstCoord);
            } else
            { 
                for (int i = 0; i < lenght; i++)
                {
                   
                }    
            }
            //baseShip.printCoord();
            this.baseShipsListFirstPlayer.Add(baseShip);
        }

        private void addShipSecondPlayer(Coordinate firstCoord, int lenght, Direction direction, BaseShip baseShip)
        {
        }

        private List<Coordinate> generateCoordShip(Coordinate firstCoord, int lenght, Direction randDirection, List<BaseShip> baseShip)
        {
            List<Coordinate> tmpList = new List<Coordinate>();
            Coordinate tmp = firstCoord;
            tmpList.Add(tmp);

            for (int i = 0; i < lenght - 1; i++)
            {
                tmp = this.createCoord(randDirection, tmp.X, tmp.Y);
                tmpList.Add(tmp);
            }

            return tmpList;
        }


        public BaseShip addCoord(Coordinate coord)
        {
            this.listCoords.Add(coord);
            return this;
        }

        public BaseShip addCoords(List<Coordinate> list)
        {
            this.listCoords.AddRange(list);
            return this;
        }

        //------------------------------------------------------------------------------------------------------

        private bool checkShipPosition(Coordinate firstCoord, int lenght, Direction direction, List<BaseShip> list)
        {
            if (lenght == 1) // алгоритм тільки для однопалубних  кораблів
            {
                foreach (BaseShip item in list)
                {
                    foreach (Coordinate coord in item.getCoordinates())
                    {
                        if (coord.X == firstCoord.X && coord.Y == firstCoord.Y)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("-----------");

                for (int i = 0; i < lenght; i++)
                {
                    foreach(Coordinate tmpCoord in this.generateCoordShip(firstCoord, lenght, direction, list))
                    {
                        foreach (BaseShip item in list)
                        {
                            foreach (Coordinate coord in item.getCoordinates())
                            {
                                if (coord.X == firstCoord.X && coord.Y == firstCoord.Y)
                                {
                                    return false;
                                }
                            }
                        }
                    }
 
                }
            }
            return true;
        }

        //--------------------------------------------------------------------------------------------------------------
        public void generateShipFirstPlayer(string name, int lenght)
        {
            BaseShip baseShip = null;
            bool isEmpty = true;
            Direction randDirection = (Direction)random.Next(0, 4);
            do
            {
                Coordinate firstCoord = new Coordinate(this.random.Next(0, 10), this.random.Next(0, 10));
                isEmpty = checkShipPosition(firstCoord, lenght, randDirection, baseShipsListFirstPlayer);
                if (isEmpty)
                {
                    switch (lenght)
                    {
                        case 1:
                            baseShip = new Destroyer(name, lenght);//створюємо корабель
                            this.addShipFirstPlayer(firstCoord, lenght, randDirection, baseShip);// і поміщаємо його в масив
                            break;
                        case 2:
                            baseShip = new Cruiser(name, lenght);
                            this.addShipFirstPlayer(firstCoord, lenght, randDirection, baseShip);
                            break;
                        case 3:
                            baseShip = new Battleship(name, lenght);
                            this.addShipFirstPlayer(firstCoord, lenght, randDirection, baseShip);
                            break;
                        case 4:
                            baseShip = new Carrier(name, lenght);
                            this.addShipFirstPlayer(firstCoord, lenght, randDirection, baseShip);
                            break;
                        default: break;
                    }
                }
            }
            while (!isEmpty); // якщо координати зайнята ідемо на нову ітерацію 
        }

        public void generateShipSecondPlayer(string name, int lenght = 1)
        {
        }


        // -----створюємо всі кораблі
        private void shipCreatorFirst(int quanquantity, int lenght, List<string> list)
        {
            for (int i = 0; i < quanquantity; i++)
            {
                this.generateShipFirstPlayer(list[random.Next(list.Count)], lenght);
            }
        }
        private void shipCreatorSecond(int quanquantity, int lenght, List<string> list)
        {
            for (int i = 0; i < quanquantity; i++)
            {
                this.generateShipSecondPlayer(list[random.Next(list.Count)], lenght);
            }
        }

        public void genereteaFleetOfShipsFirstPlayer(List<string> list) {
            shipCreatorFirst(4, 1, list);
            shipCreatorFirst(3, 2, list);
            shipCreatorFirst(2, 3, list);
            shipCreatorFirst(1, 4, list);
        }

        public void genereteaFleetOfShipsSecondPlayer(List<string> list) {
            shipCreatorSecond(4, 1, list);
            shipCreatorSecond(3, 2, list);
            shipCreatorSecond(2, 3, list);
            shipCreatorSecond(1, 4, list);
        }

        // --виводимо короблі в консоль
        public void printPlayersBoards()
        {
            this.print.printLeftField(this.baseShipsListFirstPlayer);
            this.print.printRightField(this.baseShootListFirstPlayer);
        }
    }
}
