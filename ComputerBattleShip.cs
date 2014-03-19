using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public abstract class ComputerBattleShip : BattleShip
    {
        Missle missle;

        public ComputerBattleShip(Coord topLeft, char[,] body, Coord speed,int health,int defence)
            : base(topLeft, body, speed,health,defence)
        {
            this.Speed = speed;
        }

        public Bonus GiveBonus()
        {
            if (this.IsDestroyed)
            {
                int randomNumber = Engine.randomGenerator.Next(1, 5);
                if (randomNumber == 1)
                {
                    return new UpgradeArmor(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1), new Coord(1, 0));
                }
                else if (randomNumber == 2)
                {
                    return new IncreaseHealth(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1), new Coord(1, 0));
                }
                else if (randomNumber == 3)
                {
                    this.missle = new SpaceEagleMissle();
                    return new UpgradeMissleToEagle(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1), new Coord(1, 0)); 
                }
                else
                {
                    this.missle = new SuperNovaMissle();
                    return new UpgradeMissleToSuperNova(new Coord(this.TopLeft.Row + 2, this.TopLeft.Col + 1), new Coord(1, 0)); 
                }
            }
            return null;
        }
    }
}
