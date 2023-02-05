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
        private List<Coordinate> generateCoordShip(Coordinate firstCoord, int lenght, Direction randDirection)
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
        //--------------------------------------------------------------------------------------------------------
        private void addShipPlayer(Coordinate firstCoord, int lenght, Direction randDirection, BaseShip baseShip)
        {
            if (lenght == 1)
            {
                baseShip.addCoord(firstCoord);
            }
            else
            {

            }
            //baseShip.printCoord();
            this.baseShipsListFirstPlayer.Add(baseShip);
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
                    if (i != 0)
                    {
                        firstCoord = this.createCoord(direction, firstCoord.X, firstCoord.Y);
                    }
                    foreach(Coordinate tmpCoord in this.generateCoordShip(firstCoord, lenght, direction))
                    {
                        foreach (BaseShip item in list)
                        {
                            foreach (Coordinate coord in item.getCoordinates())
                            {
                                if (coord.X == tmpCoord.X && coord.Y == tmpCoord.Y)
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
        private BaseShip createCapitalShip(Coordinate firstCoord, int lenght, Direction ranDirection, string name)
        {
            BaseShip obj = null;
            if (lenght == 2)
            {
                obj = new Cruiser(name, lenght);//створюємо корабель
            } else if (lenght == 3)
            {
                obj = new Battleship(name, lenght);
            }
            else if (lenght == 4)
            {
                obj = new Carrier(name, lenght);
            } else {
                Console.WriteLine("err");
            }

            obj.Name = name;
            obj.addCoords(generateCoordShip(firstCoord,lenght, ranDirection));
            return obj;
        }
        //--------------------------------------------------------------------------------------------------------------if
        private List<BaseShip> generateShipsPlayer(string name, int lenght, List<BaseShip> list)
        {
            BaseShip baseShip = null;
            bool isEmpty = true;
            Direction direction = (Direction)random.Next(0, 4);
            do
            {
                Coordinate firstCoord = new Coordinate(this.random.Next(0, 10), this.random.Next(0, 10));
                isEmpty = checkShipPosition(firstCoord, lenght, direction, list);
                if (isEmpty)
                {
                    list.Add(createCapitalShip(firstCoord, lenght, direction, name)); 
                }
            }
            while (!isEmpty); // якщо координати зайнята ідемо на нову ітерацію 
            return list;
        }

        // -----створюємо всі кораблі
        private void shipCreator(int quanquantity, int lenght, List<string> list)
        {
            for (int i = 0; i < quanquantity; i++)
            {
              //  this.generateShipFirstPlayer(list[random.Next(list.Count)], lenght);
            }
        }


        public void genereteaFleetOfShipsFirstPlayer(List<string> list) {
        
    
        }

        public void genereteaFleetOfShipsSecondPlayer(List<string> list) {

        }

        // --виводимо короблі в консоль
        public void printPlayersBoards()
        {
            this.print.printLeftField(this.baseShipsListFirstPlayer);
            this.print.printRightField(this.baseShootListFirstPlayer);
        }
    }
}
