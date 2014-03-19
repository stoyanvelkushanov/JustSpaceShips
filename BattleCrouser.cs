using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class BattleCrouser : ComputerBattleShip
    {
        Missle missle;
        public BattleCrouser(Coord topLeft, char[,] body, Coord speed, int health, int defence)
            : base(topLeft, body, speed,health,defence)
        {
            this.missle = new SuperNovaMissle();
            this.Damage = missle.MissleDamage;
            this.Speed = speed;
            this.color = ConsoleColor.Green;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            IList<GameObject> producedObjects = new List<GameObject>();

            if (this.produceFire && !(this.IsDestroyed))
            {
                this.produceFire = false;
                producedObjects.Add(new SuperNovaMissle(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1),
                    new Coord(3, 0),SpaceMissleProfile.superNovaReverse));
            }
            producedObjects.Add(this.GiveBonus());

            return producedObjects;
        }
    }
}
