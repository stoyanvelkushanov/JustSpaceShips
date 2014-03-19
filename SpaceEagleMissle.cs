using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class SpaceEagleMissle : Missle
    {

        public SpaceEagleMissle(Coord topLeft, Coord speed,char[,] body)
            : base(topLeft, speed,body)
        {
            this.body = body;
            this.MissleDamage = 55;
            this.color = ConsoleColor.DarkCyan;
        }

        public SpaceEagleMissle()
        {
            this.MissleDamage = 55;
        }

        public override string ToString()
        {
            return this.GetType().Name.ToString();
        }
    }
}
