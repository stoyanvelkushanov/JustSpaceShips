using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class UpgradeMissleToEagle : Bonus
    {
        private const char newMissle = 'E';

        public UpgradeMissleToEagle(Coord topLeft,Coord speed)
            : base(topLeft, new char[,] {{UpgradeMissleToEagle.newMissle}}, speed)
        {   
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
            return 0;
        }
    }
}
