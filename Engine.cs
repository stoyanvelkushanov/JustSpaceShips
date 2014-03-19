using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class Engine
    {
        List<GameObject> allObjects;
        List<ComputerBattleShip> enemyShips;

        IUserInterface userInterface;
        public ConsoleRenderer renderer;
        PlayerShip player;
        Directions direction;
        public static Random randomGenerator;

        int sleepTime;
        int difficult;

        public Engine(IUserInterface userInterface, ConsoleRenderer renderer, int sleepTime,int difficult)
        {
            this.allObjects = new List<GameObject>();
            this.enemyShips = new List<ComputerBattleShip>();
            this.userInterface = userInterface;
            this.renderer = renderer;
            this.direction = new Directions();
            this.sleepTime = sleepTime;
            randomGenerator = new Random();
            this.difficult = difficult;
        }

        public void AddObject(GameObject obj)
        {
            if (obj is PlayerShip)
            {
                this.player = obj as PlayerShip;
                this.allObjects.Add(this.player);
            }
            else if(obj is ComputerBattleShip)
            {
                this.enemyShips.Add(obj as ComputerBattleShip);
                this.allObjects.Add(obj);
            }
            else if (obj is Missle)
            {
                this.allObjects.Add(obj);
            }
            else if(obj != null)
            {
                this.allObjects.Add(obj);
            }
        }

        public void MovePlayerShipLeft()
        {
            if (this.player.TopLeft.Col > 0)
            {
                this.player.ChangePosition(direction.directions["fast-left"]);
            }
           
        }

        public void MovePlayerShipRight()
        {
            if (this.player.TopLeft.Col + (this.player as PlayerShip).GetShipLength() < this.renderer.worldCols - 1)
            {
                this.player.ChangePosition(direction.directions["fast-right"]);
            } 
        }

        public void RepairPlayerShip()
        {
            this.player.RepairShip();
        }

        public void CallHelp()
        {
            if (player.CanCallHelp() && this.player.TopLeft.Col > 10 && this.player.TopLeft.Col < this.renderer.worldCols - 10)
            {
                this.AddObject(new AlliesShipCoursair(new Coord(this.player.TopLeft.Row - 5, this.player.TopLeft.Col - 10), SpaceShipsProfiles.coursair,
                                new Coord(0, 0), 350, 10));
                this.AddObject(new AlliesShipCoursair(new Coord(this.player.TopLeft.Row - 5, this.player.TopLeft.Col + 10), SpaceShipsProfiles.coursair,
                                new Coord(0, 0), 350, 10));

                this.player.callHelpIndex = 0;
            }
        }


        private void ComputerShipsAI(List<ComputerBattleShip> enemyShips)
        {
            foreach (var obj in allObjects)
            {
                if (obj is ComputerBattleShip)
                {
                    if (obj.TopLeft.Col == 0)
                    {
                        (obj as BattleShip).ComeCloser(this.direction.directions["down"]);
                        (obj as ComputerBattleShip).ReverseDirection(this.direction.directions["right"]);
                    }

                    if (obj.TopLeft.Col + (obj as BattleShip).GetShipLength() >= this.renderer.worldCols - 1)
                    {
                        (obj as BattleShip).ComeCloser(this.direction.directions["down"]);
                        (obj as ComputerBattleShip).ReverseDirection(this.direction.directions["left"]);
                    }
                }
            }
        }

        private bool IsFirstRowFree(List<ComputerBattleShip> list)
        {
            bool isFirstRowFree = true;

            foreach (var ship in list)
            {
                int rowCoord = ship.GetShipHeight();
                List<Coord> shipCoords = ship.GetCollisionProfile();

                foreach (var coord in shipCoords)
                {
                    if (coord.Row == rowCoord - 1)
                    {
                        isFirstRowFree = false;
                    }
                }
            }

            return isFirstRowFree;
        }

        private void ProduceNewEnemy(bool isFirstRowFree,int currentShipsCount)
        {
            if (isFirstRowFree)
            {

                if (currentShipsCount == 0)
                {
                    Scout scout1 = new Scout(new Coord(0, 1), SpaceShipsProfiles.scout, direction.directions["right"], 250, 5);
                    Scout scout2 = new Scout(new Coord(3, this.renderer.worldCols-5), SpaceShipsProfiles.scout, direction.directions["left"], 250, 5);
                    Scout scout3 = new Scout(new Coord(0, 5), SpaceShipsProfiles.scout, direction.directions["right"], 250, 5);
                    Scout scout4 = new Scout(new Coord(3, this.renderer.worldCols - 10), SpaceShipsProfiles.scout, direction.directions["left"], 250, 5);
                    Destroyer destroyer1 = new Destroyer(new Coord(6, 4), SpaceShipsProfiles.destroyer, this.direction.directions["right"], 500, 10);
                    Destroyer destroyer2 = new Destroyer(new Coord(10, this.renderer.worldCols - 8), SpaceShipsProfiles.destroyer, this.direction.directions["left"], 500, 10);
                    Destroyer destroyer3 = new Destroyer(new Coord(6, 10), SpaceShipsProfiles.destroyer, this.direction.directions["right"], 500, 10);
                    Destroyer destroyer4 = new Destroyer(new Coord(10, this.renderer.worldCols - 13), SpaceShipsProfiles.destroyer, this.direction.directions["left"], 500, 10);
                    BattleCrouser bc1 = new BattleCrouser(new Coord(15, 7), SpaceShipsProfiles.battleCrouser, this.direction.directions["right"], 1000, 15);
                    BattleCrouser bc2 = new BattleCrouser(new Coord(19, this.renderer.worldCols - 11), SpaceShipsProfiles.battleCrouser, this.direction.directions["left"], 1000, 15);

                    this.AddObject(scout1);
                    this.AddObject(scout2);
                    this.AddObject(scout3);
                    this.AddObject(scout4);
                    this.AddObject(destroyer1);
                    this.AddObject(destroyer2);
                    this.AddObject(destroyer3);
                    this.AddObject(destroyer4);
                    this.AddObject(bc1);
                    this.AddObject(bc2);
                }
                Scout newShip = new Scout(new Coord(0, 6),
                    SpaceShipsProfiles.scout, this.direction.directions["right"], 250, 10);

                this.AddObject(newShip);
            }
        }
        public void Shoot()
        {
            (this.player as PlayerShip).Fire();
        }

        private void RenderPlayerShipCharacteristics()
        {
            renderer.RenderStringOnPosition(this.renderer.worldRows + 1, 2, "Health: "
                + this.player.CurrentHealth + "/" + this.player.Health, ConsoleColor.Gray);

            renderer.RenderStringOnPosition(this.renderer.worldRows + 1, 20, "Armor: " + this.player.Defence, ConsoleColor.Gray);

            renderer.RenderStringOnPosition(this.renderer.worldRows + 1, 32, "Armor upgrades: "
                + this.player.armourUpgrades + "/3", ConsoleColor.Gray);

            renderer.RenderStringOnPosition(this.renderer.worldRows + 1, 55, "Repairs: " + this.player.availableRepeirs, ConsoleColor.Gray);

            renderer.RenderStringOnPosition(this.renderer.worldRows + 1, 70, "Help: " + this.player.callHelpIndex, ConsoleColor.Gray);

            renderer.RenderStringOnPosition(this.renderer.worldRows + 3, 17, "Current missle: "
                + this.player.missle.ToString() + " - " + this.player.Damage + " damage", ConsoleColor.Gray);
        }

        //Run Game
        public void Run()
        {
            while (true)
            {
                this.userInterface.ProccessInput();

                Console.Clear();

                RenderPlayerShipCharacteristics();

                foreach (var obj in allObjects)
                {
                    obj.UpdateState();
                    this.renderer.RenderObject(obj, obj.color);
                    
                }

                System.Threading.Thread.Sleep(this.sleepTime);

                CollisionDetector.HandleCollisions(this.allObjects,this.enemyShips,this.player);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in allObjects)
                {
                    int randomNumber = randomGenerator.Next(1, 100);

                    if (obj.IsDestroyed && !(obj is Missle) && randomNumber <= 25)
                    {
                       producedObjects.AddRange(obj.ProduceObjects());
                       continue;
                    }

                    else if (randomNumber <= difficult && obj is ComputerBattleShip)
                    {
                        producedObjects.AddRange(obj.ProduceObjects());
                        (obj as ComputerBattleShip).Fire();
                    }
                    else if(obj is PlayerShip)
                    {
                        producedObjects.AddRange(obj.ProduceObjects());
                    }
                }

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }

                ComputerShipsAI(this.enemyShips);
                
                ProduceNewEnemy(IsFirstRowFree(this.enemyShips),this.enemyShips.Count);

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.enemyShips.RemoveAll(obj => obj.IsDestroyed);
            }
        } 
    }
}
