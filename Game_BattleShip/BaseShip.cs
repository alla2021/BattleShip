﻿using System.Collections.Generic;
using System;
using BaseCoord;

namespace Base
{
    public abstract class BaseShip
    {
        List<Coordinate> listCoord;
        private string name;
        protected int lenght;
        protected string shipType;

        DateTime createObjTime;
        public BaseShip(string Name, int lenght)
        {
            if (lenght <= 0 || lenght > 5)
            {
                throw new ArgumentException($"Ship length shuold be in the range 1 to 4.");
            }
            this.Name = name;
            listCoord= new List<Coordinate>();
            createObjTime = DateTime.Now.ToLocalTime();
        }
        abstract public void showType();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ShipType
        {
            get { return shipType; }
            set { shipType = value; }
        }
        public int Lenght { get; set; }

        public void printCoord()
        {
            foreach (Coordinate coord in listCoord)
            {
                Console.WriteLine($"X: {coord.X} Y: {coord.Y}");
            }
        }

        public BaseShip addCoord(Coordinate coord)
        {
            this.listCoord.Add(coord);
            return this;
        }

        public BaseShip addCoords(List<Coordinate> list)
        {
            this.listCoord.AddRange(list);
            return this;
        }

        public List<Coordinate> getCoordinates()
        {
            return this.listCoord;
        }

        public bool isHit(Coordinate shot)
        {
            for (int i = 0; i < listCoord.Count; i++)
            {
                if (shot.X == listCoord[i].X && shot.Y == listCoord[i].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}