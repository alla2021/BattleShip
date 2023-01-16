using System.Collections.Generic;
using System;

namespace Game_BattleShip
{
    public class PrintBoards
    {
        public void printLeftField(List<BaseShip> shipListPlayer)
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
                            if (coord.getX == i - 1 && coord.getY == j - 1)
                            {
                                Console.Write("S" + "|");
                            }
                        }
                    }

                }

                Console.WriteLine();
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
                        if ((shoot.Coord.getX == i - 1 && shoot.Coord.getY == j - 1) && shoot.IsHit == true)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write("o");
                        }
                    }

                }

                Console.WriteLine();
            }
        }
    }
}