using LawnMower.Logic;
using LawnMower.Models;
using System;

namespace LawnMower.Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Garden naitt= new Garden("gardenmap2.txt");

            RobotMower shaun = new RobotMower(naitt.RobotStation, Direction.Up);

            MowerLogic logic = new MowerLogic(shaun, naitt);

            logic.MapChanged += Logic_MapChanged;

            ConsoleUI.GardenDrawToConsole(logic.Garden.Map, logic.RobotMower.Position, logic.RobotMower.Direction);

            logic.DepthFirstSearch();
            
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