using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Models
{
    public class Garden
    {
        public int[,] Map { get; set; }

        public Coordinate RobotStation { get; set; }

        public Garden()
        {

        }

    }
}
