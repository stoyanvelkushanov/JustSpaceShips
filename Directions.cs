using System;
using System.Collections.Generic;

namespace JustSpaceShips
{
    public class Directions
    {
        public  Dictionary<string, Coord> directions;

        public Directions()
        {
            directions = new Dictionary<string, Coord>();

            directions.Add("right", new Coord(0,1));
            directions.Add("left", new Coord(0, -1));
            directions.Add("down", new Coord(2, 0));
            directions.Add("up", new Coord(-1, 0));
            directions.Add("fast-right", new Coord(0, 2));
            directions.Add("fast-left", new Coord(0, -2));
        }
    }
}
