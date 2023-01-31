using System.Collections.Generic;
using System;
using BaseCoord;

namespace Base
{
    public abstract class BaseShip
    {
        List<Coordinate> listCoords;
        private string name;
        protected int lenght;
        protected string shipType;

        DateTime createObjTime;
        public BaseShip(string Name, int Lenght)
        {
            if (Lenght <= 0 || Lenght > 10)
            {
                throw new ArgumentException($"Ship length shuold be in the range 1 to 10.");
            }
            this.Name = name;
            listCoords = new List<Coordinate>();
            createObjTime = DateTime.Now.ToLocalTime();
        }
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
            foreach (Coordinate coord in listCoords)
            {
                Console.WriteLine($"X: {coord.X} Y: {coord.Y}");
            }
        }

        public BaseShip addCoord(Coordinate coord)
        {
            this.listCoords.Add(coord);
            return this;
        }

        public List<Coordinate> getCoordinates()
        {
            return this.listCoords;
        }


        public bool isHit(Coordinate shot)
        {
            for (int i = 0; i < listCoords.Count; i++)
            {
                if (shot.X == listCoords[i].X && shot.Y == listCoords[i].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}