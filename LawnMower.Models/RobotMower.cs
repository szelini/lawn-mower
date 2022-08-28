using LawnMower.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Models
{
    public class RobotMower : IRobot
    {

        private Dictionary<Direction, (int row, int col)> valuesToAdd = new Dictionary<Direction, (int row, int col)>()
        {
            { Direction.Up, (-1,0)},
            { Direction.Right, (0,1) },
            { Direction.Down, (1,0) },
            { Direction.Left, (0,-1) },
        };

        public Coordinate Position { get; set; }

        public Direction Direction { get; set; }

        public RobotMower(Coordinate coordinate, Direction direction)
        {
            this.Position = coordinate;
            this.Direction = direction;
        }

        public void Step()
        {

        }

        public void TurnRight()
        {
           
        }

    }
}
