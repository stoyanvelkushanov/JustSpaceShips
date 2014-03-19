using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class SpaceAntMissle : Missle
    {
        public SpaceAntMissle(Coord topLeft, Coord speed,char[,] body)
            : base(topLeft, speed,body)
        {
            this.MissleDamage = 40;
            this.body = body;
            this.color = ConsoleColor.White;
        }

        public SpaceAntMissle()
        {
            this.MissleDamage = 40;
        }

        public override string ToString()
        {
            return this.GetType().Name.ToString();
        }
    }
}
