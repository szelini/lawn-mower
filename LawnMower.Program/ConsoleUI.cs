using LawnMower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Program
{
    public class ConsoleUI
    {
        public static void GardenDrawToConsole(int[,] map, Coordinate robopos, Direction dir)
        {
            Console.Clear();

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
                            Console.ForegroundColor = ConsoleColor.Yellow;
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
