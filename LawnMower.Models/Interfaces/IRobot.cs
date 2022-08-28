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
        Coordinate CalculatNextStep();
        void Step();
        void TurnRight();
        void TurnLeft();

    }
}
