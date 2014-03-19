using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSpaceShips
{
   public abstract class Missle:MovingObject
    {

        public int MissleDamage { get; protected set; }

        public Missle(Coord topLeft, Coord speed,char[,] body)
            : base(topLeft,new char[,] {{' '}},speed)
        {
        }

        public Missle()
        {
        }

        public override void UpdateState()
        {
            this.TopLeft += this.Speed;

            if (this.TopLeft.Row < 0 || this.TopLeft.Row > ConsoleRenderer.Rows)
            {
                IsDestroyed = true;
            }
        }

        public override void RespondToCollision()
        {
            this.IsDestroyed = true;
        }
    }
}
