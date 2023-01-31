using System.Collections.Generic;
using System;
using Base;
using BaseCoord;
using BaseShoot;

namespace Game_BattleShip
{
    public class PrintBoards
    {
        public void printLeftField(List<BaseShip> shipListPlayer)
        {
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (j == 0 && i == 0)
                        {
                            Console.Write("  ");
                        }
                        else if (i == 0 && j != 0)
                        {
                            Console.Write((j - 1) + "|");
                        }

                        if (i != 0 && j == 0)
                        {
                            Console.Write((i - 1) + "|");
                        }

                        foreach (BaseShip ship in shipListPlayer) 
                        {                            
                            foreach (Coordinate coord in ship.getCoordinates())
                            {
                                if (coord.X == i - 1 && coord.Y == j - 1)
                                {                                   
                                    Console.Write("O" + " "); // малювання корабля
                                } 

                            }
                        }

                    }
                    Console.WriteLine();
                }
            }
        }

        public void printRightField(List<Shoot> shootListPlayer)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (j == 0 && i == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (i == 0 && j != 0)
                    {
                        Console.Write((j - 1) + "|");
                    }

                    if (i != 0 && j == 0)
                    {
                        Console.Write((i - 1) + "|");
                    }

                    foreach (Shoot shoot in shootListPlayer)
                    {
                        if ((shoot.Coord.X == i - 1 && shoot.Coord.Y == j - 1) && shoot.IsHit == true)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write("~");
                        }
                    }

                }

                Console.WriteLine();
            }
        }
    }
}