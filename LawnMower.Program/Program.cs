using LawnMower.Logic;
using LawnMower.Models;
using System;

namespace LawnMower.Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Garden hereIsTheGarden = new Garden("gardenmap1.txt");

            RobotMower shaunTheMower = new RobotMower(hereIsTheGarden.RobotStation, Direction.Up);

            MowerLogic logic = new MowerLogic(shaunTheMower, hereIsTheGarden);

            logic.MapChanged += Logic_MapChanged;

            ConsoleUI.GardenDrawToConsole(logic.Garden.Map, logic.RobotMower.Position, logic.RobotMower.Direction);

            Console.ReadKey();

            logic.DepthFirstSearch();

            ConsoleUI.GardenDrawToConsole(logic.Garden.Map, logic.RobotMower.Position, logic.RobotMower.Direction);

            Console.ReadKey();
        }

        private static void Logic_MapChanged(object? sender, EventArgs e)
        {
            var senderLogic = sender as MowerLogic;

            if(senderLogic != null)
            {
                ConsoleUI.GardenDrawToConsole(senderLogic.Garden.Map, senderLogic.RobotMower.Position, senderLogic.RobotMower.Direction);
            }
        }
       
    }
}