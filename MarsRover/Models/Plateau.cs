using System;
using System.Collections.Generic;
using MarsRover.Factory;

namespace MarsRover.Models
{
    public class Plateau
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public List<Rover> Rovers { get; set; }

        public Plateau(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Rovers = new List<Rover>();
        }

        public void LandRover(Rover rover)
        {
            var roverPosition = rover.GetPosition();
            if (roverPosition.Coordinate.X > SizeX ||
                roverPosition.Coordinate.X < 0 ||
                roverPosition.Coordinate.Y > SizeY ||
                roverPosition.Coordinate.Y < 0)
                throw new ArgumentOutOfRangeException();

            rover.Plateau = this;
            this.Rovers.Add(rover);
        }

        public void MoveRover(Rover rover, string commands)
        {
            var factory = CommandFactory.CommandBuilder(commands);
            rover.Move(factory);
        }

        public void LocateRovers()
        {
            foreach (var rover in this.Rovers)
            {
               rover.PrintPosition(); 
            }
        }
    }
}
