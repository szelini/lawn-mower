using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Models
{
    public class Coordinate
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public override bool Equals(object? obj)
        {
            return obj is Coordinate coordinate &&
                   Row == coordinate.Row &&
                   Col == coordinate.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }
    }
}
