using LawnMower.Models;
using LawnMower.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Logic
{
    public class MowerLogic
    {
        public IRobot RobotMower { get; set; }
        public ITerritory Garden { get; set; }

        private HashSet<Coordinate> MowedCoordinates { get; set; }

        public MowerLogic(IRobot robotMower, ITerritory garden)
        {
            this.RobotMower = robotMower;
            this.Garden = garden;
            this.MowedCoordinates = new HashSet<Coordinate>();
        }

        public void DepthFirstSearch()
        {
            //eljárás MélységiBejárásRek(k, címsz.F)
            //    F <- F ∪ { k}
            //    Feldolgoz(k.tart)
            //    ciklus Vx E k.Szomszédok
            //        ha x !E F akkor
            //            MélységiBejárásRek(x, F)
            //        elágazás vége
            //   ciklus vége
            //eljárás vége

            if (!MowedCoordinates.Add(this.RobotMower.Position)) //    F <- F ∪ { k}
            {
                return;
            }
            MowPosition(); //Feldolgoz(k.tart)

            for (int i = 0; i < 4; i++) //#todo: not to burn directions number
            {

                Coordinate newPosition = this.RobotMower.CalculatNextStep();

                if (IsValidPosition(newPosition))
                {
                    RobotMower.Step();

                    Console.Clear();
                    GardenDrawToConsole(this.Garden.Map, RobotMower.Position, RobotMower.Direction); //#todo delete console operations

                    this.DepthFirstSearch();
                    RobotMower.TurnLeft();
                    Console.Clear();
                    GardenDrawToConsole(this.Garden.Map, RobotMower.Position, RobotMower.Direction);
                    RobotMower.TurnLeft(); //step back to the previous cell
                    Console.Clear();
                    GardenDrawToConsole(this.Garden.Map, RobotMower.Position, RobotMower.Direction);
                    RobotMower.Step();

                    Console.Clear();
                    GardenDrawToConsole(this.Garden.Map, RobotMower.Position, RobotMower.Direction); //#todo delete console operations

                    RobotMower.TurnRight();
                    Console.Clear();
                    GardenDrawToConsole(this.Garden.Map, RobotMower.Position, RobotMower.Direction);
                    RobotMower.TurnRight(); //direction set to previous
                    Console.Clear();
                    GardenDrawToConsole(this.Garden.Map, RobotMower.Position, RobotMower.Direction);
                }

                RobotMower.TurnRight(); //turn to check the next direction
                Console.Clear();
                GardenDrawToConsole(this.Garden.Map, RobotMower.Position, RobotMower.Direction);

            }
        }

        private void MowPosition()
        {
            this.Garden.Map[this.RobotMower.Position.Row, this.RobotMower.Position.Col] = 1;
        }

        private bool IsValidPosition(Coordinate position)
        {
            if (position.Row >= Garden.Map.GetLength(0) || position.Row < 0 || position.Col >= Garden.Map.GetLength(1) || position.Col < 0)
            {
                return false;
            }

            if (Garden.Map[position.Row, position.Col] != 0)
            {
                return false;
            } 

            return true;
        }

        public void GardenDrawToConsole(int[,] map, Coordinate robopos, Direction dir) //#todo delete console operations
        {

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (robopos.Row == i && robopos.Col == j)
                    {
                        char roboChar;

                        switch (dir)
                        {
                            case Direction.Up:
                                roboChar = 'A';
                                break;
                            case Direction.Left:
                                roboChar = '<';
                                break;
                            case Direction.Down:
                                roboChar = 'V';
                                break;
                            case Direction.Right:
                                roboChar = '>';
                                break;
                            default:
                                roboChar = '*';
                                break;
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(roboChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        if (map[i, j] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        if (map[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (map[i, j] == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }

                        Console.Write(map[i, j]);
                        Console.ResetColor();
                    }

                    if (j != map.GetLength(1) - 1)
                    {
                        Console.Write("\t");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Thread.Sleep(700);
        }
    }
}
