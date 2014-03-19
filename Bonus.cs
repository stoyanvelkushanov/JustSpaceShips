using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public abstract class Bonus : MovingObject
    {
        public Bonus(Coord topLeft, char[,] body,Coord speed)
            : base(topLeft, body, speed)
        {
            this.color = ConsoleColor.Red;
        }

        public override void UpdateState()
        {
            this.TopLeft += this.Speed;
        }

        public override void RespondToCollision()
        {
            this.IsDestroyed = true;
        }

        public abstract int ActByYourKindOfBonus();


    }
}
