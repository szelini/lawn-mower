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

        public Garden()
        {
            this.Map = new int[5, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, -1, 0, 0, 0, -1, 0 }, { 0, -1, 0, -1, 0, -1, 0 }, { 0, -1, 0, 0, 0, -1, 0 }, { 0, 0, 0, 0, 0, 0, 0} };  //#todo data load
        }

    }
}
