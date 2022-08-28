using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Models.Interfaces
{
    public interface IRobot
    {
        Coordinate Position { get; set; }
        Direction Direction { get; set; }
        void Step();
        void TurnRight();
    }
}
