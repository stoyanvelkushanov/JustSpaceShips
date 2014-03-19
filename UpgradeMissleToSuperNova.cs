using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class UpgradeMissleToSuperNova : Bonus
    {
        private const char newMissle = 'S';

        public UpgradeMissleToSuperNova(Coord topLeft, Coord speed)
            : base(topLeft, new char[,] { { UpgradeMissleToSuperNova.newMissle } }, speed)
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
