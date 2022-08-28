using LawnMower.Models;
using LawnMower.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Logic
{
    public class MowerLogic
    {
        public IRobot RobotMower { get; set; }
        public ITerritory Garden { get; set; }

        private HashSet<Coordinate> MowedCoordinates { get; set; }

        public event EventHandler MapChanged;

        public MowerLogic(IRobot robotMower, ITerritory garden)
        {
            this.RobotMower = robotMower;
            this.Garden = garden;
            this.MowedCoordinates = new HashSet<Coordinate>();
        }

        public void DepthFirstSearch()
        {
            //eljárás MélységiBejárásRek(k, címsz.F)
            //    F <- F ∪ { k}
            //    Feldolgoz(k.tart)
            //    ciklus Vx E k.Szomszédok
            //        ha x !E F akkor
            //            MélységiBejárásRek(x, F)
            //        elágazás vége
            //   ciklus vége
            //eljárás vége

            try
            {
                if (!MowedCoordinates.Add(this.RobotMower.Position)) //    F <- F ∪ { k}
                {
                    return;
                }
                MowPosition(); //Feldolgoz(k.tart)

                for (int i = 0; i < 4; i++) //#todo: not to burn directions number
                {

                    Coordinate newPosition = this.RobotMower.CalculatNextStep();

                    if (IsValidPosition(newPosition))
                    {
                        RobotMower.Step();
                        MapChanged?.Invoke(this, EventArgs.Empty);
                        
                        this.DepthFirstSearch();
                        RobotMower.TurnLeft();
                        RobotMower.TurnLeft(); //step back to the previous cell
                        MapChanged?.Invoke(this, EventArgs.Empty);
                        
                        RobotMower.Step();

                        MapChanged?.Invoke(this, EventArgs.Empty);
                       

                        RobotMower.TurnRight();
                        RobotMower.TurnRight(); //direction set to previous

                        MapChanged?.Invoke(this, EventArgs.Empty);
                       
                    }
                   
                    RobotMower.TurnRight(); //turn to check the next direction

                    MapChanged?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void MowPosition()
        {
            this.Garden.Map[this.RobotMower.Position.Row, this.RobotMower.Position.Col] = 1;
        }

        private bool IsValidPosition(Coordinate position)
        {
            if (position.Row >= Garden.Map.GetLength(0) || position.Row < 0 || position.Col >= Garden.Map.GetLength(1) || position.Col < 0)
            {
                return false;
            }

            if (Garden.Map[position.Row, position.Col] != 0)
            {
                return false;
            } 

            return true;
        }
        
    }
}
