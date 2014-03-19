using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class CollisionDetector
    {
        public static void HandleCollisions(List<GameObject> allObjects,List<ComputerBattleShip> enemyShips,PlayerShip player)
        {
            List<Missle> enemyMissles = new List<Missle>();
            List<Missle> playerMissles = new List<Missle>();
            List<Bonus> bonuses = new List<Bonus>();

            PlayerShip playerShip = allObjects[0] as PlayerShip;

            foreach (var obj in allObjects)
            {
                if ((obj as MovingObject).Speed.Row > 0 && obj is Missle)
                {
                    enemyMissles.Add(obj as Missle);
                }
                else if ((obj as MovingObject).Speed.Row < 0 && obj is Missle)
                {
                    playerMissles.Add(obj as Missle);
                }
                else if (obj is Bonus)
                {
                    bonuses.Add(obj as Bonus);
                }
            }

            CollisionWithEnemyShips(enemyShips, playerMissles);

            CollisionsWithPlayerShip(playerShip, enemyMissles);

            CollisionWithBonus(playerShip, bonuses);
        }

        private static void CollisionWithBonus(PlayerShip playerShip, List<Bonus> bonuses)
        {
            List<Coord> collisionProfile = playerShip.GetCollisionProfile();

            foreach (var bonus in bonuses)
            {
                Bonus currentBonus = bonus;

                for (int i = 0; i < collisionProfile.Count; i++)
                {
                    if (currentBonus.TopLeft.Row == collisionProfile[i].Row && currentBonus.TopLeft.Col == collisionProfile[i].Col)
                    {
                        if (currentBonus is IncreaseHealth)
                        {
                            int health = (currentBonus as IncreaseHealth).ActByYourKindOfBonus();
                            playerShip.RecieveHealthBonus(health);
                        }
                        else if (currentBonus is UpgradeArmor)
                        {
                            int armor = (currentBonus as UpgradeArmor).ActByYourKindOfBonus();
                            playerShip.RecieveArmorBonus(armor);
                        }
                        else if (currentBonus is UpgradeMissleToEagle)
                        {
                            playerShip.RecieveEagleMissleBonus();
                        }
                        else if (currentBonus is UpgradeMissleToSuperNova)
                        {
                            playerShip.RecieveNovaMissleBonus();
                        }
                        currentBonus.RespondToCollision();
                        break;
                    }
                }
            }
        }

        private static void CollisionWithEnemyShips(List<ComputerBattleShip> enemyShips, List<Missle> playerMissles)
        {
            bool isShipHitted = false;

            foreach (var missle in playerMissles)
            {
                Missle currenyMissle = missle;

                foreach (var enemyShip in enemyShips)
                {
                    List<Coord> collisionProfile = enemyShip.GetCollisionProfile();

                    for (int i = 0; i < collisionProfile.Count; i++)
                    {
                        if (currenyMissle.TopLeft.Row == collisionProfile[i].Row
                            && currenyMissle.TopLeft.Col == collisionProfile[i].Col)
                        {
                            int missleDamage = currenyMissle.MissleDamage - enemyShip.Defence;

                            if (missleDamage > 0)
                            {
                                enemyShip.CurrentHealth -= missleDamage;
                            }
                            enemyShip.RespondToCollision();
                            currenyMissle.RespondToCollision();
                            isShipHitted = true;
                            break;
                        }
                    }
                    if (isShipHitted)
                    {
                        isShipHitted = false;
                        break;
                    }
                }
            }
        }
        private static void CollisionsWithPlayerShip(PlayerShip playerShip, List<Missle> enemyMissles)
        {
            List<Coord> collisionProfile = playerShip.GetCollisionProfile();

            foreach (var missle in enemyMissles)
            {
                Missle currentRocket = missle;

                for (int i = 0; i < collisionProfile.Count; i++)
                {
                    if (currentRocket.TopLeft.Row == collisionProfile[i].Row && currentRocket.TopLeft.Col == collisionProfile[i].Col)
                    {
                        int damageByMissle = missle.MissleDamage - playerShip.Defence;
                        if (damageByMissle > 0)
                        {
                            playerShip.CurrentHealth -= damageByMissle;
                        }
                        playerShip.RespondToCollision();
                        missle.RespondToCollision();
                        break;
                    }
                }
            }
        }
    }
}
