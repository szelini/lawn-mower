using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Models
{
    public enum Direction
    {
        Up, //0     Row: -1, Col: 0
        Right, //1       Row: 0, Col: -1
        Down, //2        Row: 1, Col: 0
        Left, //3      Row: 0, Col: 1
    }
}
