using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class IncreaseHealth : Bonus
    {
        private const char health = 'H';
        int Health;

        public IncreaseHealth(Coord topLeft, Coord speed)
            : base(topLeft, new char[,] {{IncreaseHealth.health}}, speed)
        {
            this.Health = Engine.randomGenerator.Next(25, 50);
        }

        public override void RespondToCollision()
        {
            base.RespondToCollision();
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override int ActByYourKindOfBonus()
        {
            return this.Health;
        }
    }
}
