using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class SuperNovaMissle : Missle
    {
        public SuperNovaMissle(Coord topLeft, Coord speed, char[,] body)
            : base(topLeft, speed, body)
        {
            this.body = body;
            this.MissleDamage = 80;
            this.color = ConsoleColor.Yellow;
        }

        public SuperNovaMissle()
        {
            this.MissleDamage = 80;
        }
        public override string ToString()
        {
            return this.GetType().Name.ToString();
        }
    }
}
