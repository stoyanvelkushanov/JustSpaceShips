using System;
using System.Collections.Generic;

namespace JustSpaceShips
{
    public class PlayerShip : BattleShip
    {
       public int armourUpgrades;
       public Missle missle;
       public int availableRepeirs;
       public int callHelpIndex;

        public PlayerShip(Coord topLeft, char[,] body, Coord speed, int health,int defence)
            : base(topLeft, body, speed, health, defence)
        {
            this.missle = new SpaceAntMissle();
            this.Damage = missle.MissleDamage;
            this.armourUpgrades = 0;
            this.color = ConsoleColor.Red;
            this.availableRepeirs = 3;
            this.callHelpIndex = 1;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            IList<GameObject> producedObjects = new List<GameObject>();

            if (produceFire)
            {
                produceFire = false;

                if (this.missle is SpaceAntMissle)
                {
                    producedObjects.Add(new SpaceAntMissle(new Coord(this.TopLeft.Row, this.TopLeft.Col + 2),
                    new Coord(-3, 0),SpaceMissleProfile.antMissle));
                }
                else if (this.missle is SpaceEagleMissle)
                {
                    producedObjects.Add(new SpaceEagleMissle(new Coord(this.TopLeft.Row, this.TopLeft.Col + 1),
                    new Coord(-3, 0),SpaceMissleProfile.eagleMissle));
                }
                else
                {
                    producedObjects.Add(new SuperNovaMissle(new Coord(this.TopLeft.Row, this.TopLeft.Col + 1),
                    new Coord(-3, 0), SpaceMissleProfile.superNova));
                }
            }
            return producedObjects;
        }
        
        public void RecieveHealthBonus(int health)
        {
            this.Health += health;
        }

        public void RecieveArmorBonus(int armor)
        {
            if (this.armourUpgrades < 3)
            {
                this.armourUpgrades++;
                this.Defence += armor;
            }
            if (armourUpgrades > 3)
            {
                armourUpgrades = 3;
            }
        }

        public void RecieveEagleMissleBonus()
        {
            this.missle = new SpaceEagleMissle();
            this.Damage = missle.MissleDamage;
        }

        public void RecieveNovaMissleBonus()
        {
            this.missle = new SuperNovaMissle();
            this.Damage = missle.MissleDamage;
        }
        public override void UpdateState()
        {
        }

        public void RepairShip()
        {
            if (this.CurrentHealth <= 250 && this.availableRepeirs > 0)
            {
                this.availableRepeirs--;
                this.CurrentHealth = this.Health;
            }
        }

        public bool CanCallHelp()
        {
            if (this.callHelpIndex > 0)
            {
                return true;
            }
            return false;
        }
    }
}
