using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Models.Interfaces
{
    public interface ITerritory
    {
        int[,] Map { get; set; }
        Coordinate RobotStation { get; set; }
    }
}
