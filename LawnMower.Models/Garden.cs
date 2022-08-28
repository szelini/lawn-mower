using LawnMower.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Models
{
    public class Garden : ITerritory
    {
        public int[,] Map { get; set; }

        public Coordinate RobotStation { get; set; }

        public Garden(string fileName)
        {
            loadMapFromTxtFile(fileName);
        }

        public void loadMapFromTxtFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName, Encoding.Default);
                
                //mower station position is in the file's 1st line
                string[] coords = lines[0].Split(';');
                
                this.RobotStation = new Coordinate(int.Parse(coords[0]), int.Parse(coords[1])); // #todo check if is in map
                
                int mapRowsCount = lines.Length - 1;
                int mapColsCount = mapRowsCount > 0 ? lines[1].Split(',').Length : 0;

                if (mapColsCount > 0)
                {
                    this.Map = new int[mapRowsCount, mapColsCount];
                    for (int i = 0; i < mapRowsCount; i++)
                    {
                        string[] chars = lines[i+1].Split(',');

                        for (int j = 0; j < mapColsCount; j++)
                        {
                            Map[i,j] = int.Parse(chars[j]);
                        }
                    }
                }
            }

            catch (IOException ex)
            {
                Console.WriteLine("File reading error!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
