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
        // постріли
        public void addShootFirstPlayer(Shoot shoot)
        {
            this.baseShootListFirstPlayer.Add(shoot);
        }

        public void addShootSecondPlayer(Shoot shoot)
        {
            this.baseShootListSecondPlayer.Add(shoot);
        }

        private Coordinate createCoord(Coordinate coord, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    coord = new Coordinate(coord.X, coord.Y++);
                    break;
                case Direction.East:
                    coord = new Coordinate(coord.X++, coord.Y);
                    break;
                case Direction.South:
                    coord = new Coordinate(coord.X, coord.Y--);
                    break;
                case Direction.West:
                    coord = new Coordinate(coord.X--, coord.Y);
                    break;
            }
            return coord;
        }
        //--------------------------------------------------------------------------------------------------------

        private void addShipFirstPlayer(Coordinate coord, int lenght, Direction randDirection, BaseShip baseShip)
        {
            if (lenght == 1)
            {
                baseShip.addCoord(coord);
            } else
            {
                for (int i = 0; i < lenght; i++)
                {
                    coord = this.createCoord(coord, randDirection); 
                    baseShip.addCoord(coord);             
                }    
            }
            baseShip.printCoord();
            this.baseShipsListFirstPlayer.Add(baseShip);
        }

        private void addShipSecondPlayer(Coordinate firstCoord, int lenght, Direction direction, BaseShip baseShip)
        {
            for (int i = 0; i < lenght; i++)
            {
                firstCoord = this.createCoord(firstCoord, direction);
                baseShip.addCoord(firstCoord);
            }
            this.baseShipsListSecondPlayer.Add(baseShip);
        }
        //--------------------------------------------------------------------------------------------------------------

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
            return true;
        }

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

        private void shipCreator(int quanquantity, int lenght, List<string> list)
        {
            for (int i = 0; i < quanquantity; i++)
            {
                Console.Write(list[random.Next(list.Count)]+" --");
                this.generateShipFirstPlayer(list[random.Next(list.Count)], lenght);
            }
        } 

        public void genereteaFleetOfShipsFirstPlayer(List<string> list) {
            shipCreator(4, 1, list);
            shipCreator(3, 2, list);
            shipCreator(2, 3, list);
            this.generateShipFirstPlayer("ship", 4);
        }



        public void genereteaFleetOfShipsSecondPlayer(List<string> list) {
            shipCreator(4, 1, list);
            this.generateShipSecondPlayer("ship", 4);
        }

        public void printPlayersBoards()
        {
            this.print.printLeftField(this.baseShipsListFirstPlayer);
            this.print.printRightField(this.baseShootListFirstPlayer);
        }
    }
}
