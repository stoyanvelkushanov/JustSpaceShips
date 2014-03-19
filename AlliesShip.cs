using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class AlliesShipCoursair:ComputerBattleShip

    {
        private int helpTime;

        public AlliesShipCoursair(Coord topLeft, char[,] body, Coord speed, int health, int defence)
            : base(topLeft, body, speed,health,defence)
        {
            this.Speed = speed;
            this.color = ConsoleColor.Green;
            this.helpTime = 1000;
        }

        public override void UpdateState()
        {
            this.helpTime--;

            if (this.helpTime <= 0)
            {
                this.IsDestroyed = true;
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            IList<GameObject> producedObjects = new List<GameObject>();

            if (this.produceFire && !(this.IsDestroyed))
            {
                this.produceFire = false;
                producedObjects.Add(new SpaceEagleMissle(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1),
                    new Coord(-3, 0), SpaceMissleProfile.eagleMissleReverse));
            }

            return producedObjects;
        }
    }
}
