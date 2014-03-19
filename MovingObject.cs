using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public abstract class MovingObject : GameObject
    {
        public Coord Speed { get; protected set; }

        public MovingObject(Coord topLeft, char[,] body, Coord speed):base(topLeft,body)
        {
            this.Speed = speed;
        }
        public MovingObject()
        {
        }

        public override void UpdateState()
        {
            this.TopLeft += this.Speed;
        }

        public void ReverseDirection(Coord speed)
        {
            this.Speed = speed;
        }
        public void ChangePosition(Coord newSpeed)
        {
            this.Speed = newSpeed;
            this.TopLeft += Speed;
        }
    }
}
