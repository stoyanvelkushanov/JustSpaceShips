using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public abstract class BattleShip : MovingObject
    {
        private int health;
        private int damage;
        private int defence;
        private int currentHealth;

        protected bool produceFire;

        public BattleShip(Coord topLeft, char[,] body, Coord speed, int health, int defence)
            : base(topLeft, body, speed)
        {
            this.health = health;
            this.defence = defence;
            currentHealth = health;
            this.produceFire = false;
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public int Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        public int Defence
        {
            get { return this.defence; }
            set { this.defence = value; }
        }
        public int CurrentHealth
        {
            get { return this.currentHealth; }
            set { this.currentHealth = value; }
        }

        public int GetShipLength()
        {
            return this.body.GetLength(1);
        }

        public int GetShipHeight()
        {
            return this.body.GetLength(0);
        }
        public void ComeCloser(Coord coord)
        {
            this.TopLeft += coord;
        }
        public override void RespondToCollision()
        {
            if (this.currentHealth <= 0)
            {
                this.IsDestroyed = true;
            }
        }

        public void Fire()
        {
            this.produceFire = true;
        }
    }
}
