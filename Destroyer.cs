using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class Destroyer : ComputerBattleShip
    {
        Missle missle;

        public Destroyer(Coord topLeft, char[,] body, Coord speed, int health, int defence)
            : base(topLeft, body, speed,health,defence)
        {
            this.missle = new SpaceEagleMissle();
            this.Damage = missle.MissleDamage;
            this.Speed = speed;
            this.color = ConsoleColor.Magenta;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            IList<GameObject> producedObjects = new List<GameObject>();

            if (this.produceFire && !(this.IsDestroyed))
            {
                this.produceFire = false;
                producedObjects.Add(new SpaceEagleMissle(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1),
                    new Coord(3, 0),SpaceMissleProfile.eagleMissleReverse));
            }
            producedObjects.Add(this.GiveBonus());

            return producedObjects;
        }
    }
}
