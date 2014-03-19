using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class UpgradeArmor : Bonus
    {
        private const char armor = 'A';
        public int Armor;

        public UpgradeArmor(Coord topLeft, Coord speed)
            : base(topLeft,new char[,] {{UpgradeArmor.armor}}, speed)
        {
            this.Armor = 6;
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
            return this.Armor;
        }
    }
}
