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
        public BaseShip(string Name)
        {
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
                Console.WriteLine($"X: {coord.getX} Y: {coord.getY}");
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
                if (shot.getX == listCoords[i].getX && shot.getY == listCoords[i].getY)
                {
                    return true;
                }
            }
            return false;
        }
    }
}