using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSpaceShips
{
    class Program
    {
        private static void InitializeGame(Engine engine)
        {
            Console.CursorVisible = false;
            Console.WindowHeight = engine.renderer.worldRows + 4;
            Console.BufferHeight = engine.renderer.worldRows + 4;

            Console.WindowWidth = engine.renderer.worldCols;
            Console.BufferWidth = engine.renderer.worldCols;

            BattleShip playerShip = new PlayerShip(new Coord(45, 16), SpaceShipsProfiles.coursair, new Coord(0, 0), 600, 10);

            engine.AddObject(playerShip);

            Scout scout1 = new Scout(new Coord(0, 1), SpaceShipsProfiles.scout, new Coord(0,1), 250, 5);
            Scout scout2 = new Scout(new Coord(3, engine.renderer.worldCols - 5), SpaceShipsProfiles.scout, new Coord(0,-1), 250, 5);
            Destroyer destroyer1 = new Destroyer(new Coord(6,4), SpaceShipsProfiles.destroyer, new Coord(0, 1), 500, 10);
            Destroyer destroyer2 = new Destroyer(new Coord(10, engine.renderer.worldCols - 8), SpaceShipsProfiles.destroyer, new Coord(0, -1), 500, 10);
            BattleCrouser bc1 = new BattleCrouser(new Coord(15, 7), SpaceShipsProfiles.battleCrouser, new Coord(0, 1), 1000, 15);
            BattleCrouser bc2 = new BattleCrouser(new Coord(19, engine.renderer.worldCols - 11), SpaceShipsProfiles.battleCrouser, new Coord(0, -1), 1000, 15);

            engine.AddObject(scout1);
            engine.AddObject(scout2);
            engine.AddObject(destroyer1);
            engine.AddObject(destroyer2);
            engine.AddObject(bc1);
            engine.AddObject(bc2); 
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            ConsoleRenderer renderer = new ConsoleRenderer(50, 80);
            IUserInterface userInterface = new KeyboardController();

            Engine engine = new Engine(userInterface, renderer,70,5);

            InitializeGame(engine);
            
            userInterface.onFirePressed += (sender, eventInfo) =>
                {
                    engine.Shoot();
                };
            userInterface.onLeftPressed += (sender, eventInfo) =>
                {
                    engine.MovePlayerShipLeft();
                };
            userInterface.onRightPressed += (sender, eventInfo) =>
                {
                    engine.MovePlayerShipRight();
                };
            userInterface.onRepairPressed += (sender, eventInfo) =>
                {
                    engine.RepairPlayerShip();
                };
            userInterface.onHelpPressed += (sender, eventInfo) =>
                {
                    engine.CallHelp();
                };

            engine.Run();
        }

        
    }
}
