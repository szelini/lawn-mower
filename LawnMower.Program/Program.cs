using LawnMower.Logic;
using LawnMower.Models;
using System;

namespace LawnMower.Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            RobotMower shaun = new RobotMower(new Coordinate(4, 2), Direction.Up);
            
            Garden naitt= new Garden();

            MowerLogic logic = new MowerLogic(shaun, naitt);

            logic.DepthFirstSearch();

            logic.GardenDrawToConsole(naitt.Map, shaun.Position, shaun.Direction); //#todo delete
        }
    }
}