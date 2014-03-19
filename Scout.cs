using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class Scout : ComputerBattleShip
    {
        Missle missle;

        public Scout(Coord topLeft, char[,] body, Coord speed,int health,int defence)
            : base(topLeft, body, speed,health,defence)
        {
            this.missle = new SpaceAntMissle();
            this.Damage = missle.MissleDamage;
            this.Speed = speed;
            this.color = ConsoleColor.Blue;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            IList<GameObject> producedObjects = new List<GameObject>();

            if (this.produceFire && !this.IsDestroyed)
            {
                this.produceFire = false;
                producedObjects.Add(new SpaceAntMissle(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1),
                    new Coord(3, 0),SpaceMissleProfile.antMissleReverse));
            }

           producedObjects.Add(this.GiveBonus());

            return producedObjects;
        }
    }
}
