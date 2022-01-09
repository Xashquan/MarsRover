using System;
using System.Collections.Generic;
using MarsRover.Models.RoverCommands;

namespace MarsRover.Models
{
    public class Rover
    {
        private readonly Position _position;
        public Plateau Plateau { get; set; }
        public Rover(Position position)
        {
            _position = position;
        }

        public Position GetPosition()
        {
            return this._position;
        }

        public void Move(IRoverCommand command)
        {
            ExecuteCommand((dynamic)command);
        }

        public void Move(List<IRoverCommand> commands)
        {
            foreach (var command in commands)
            {
                ExecuteCommand((dynamic)command);
            }
        }

        public void PrintPosition()
        {
            Console.WriteLine($"{this._position.Coordinate.X} {this._position.Coordinate.Y} {this._position.Direction}");
        }

        private void ExecuteCommand(MoveForwardCommand command)
        {
            var nextCoordinate = _position.GetNextCoordinate();
            if (IsInsideArea(nextCoordinate))
            {
               _position.MoveForward();
            }
        }

        private void ExecuteCommand(TurnLeftCommand command)
        {
            _position.TurnLeft();
        }

        private void ExecuteCommand(TurnRightCommand command)
        {
            _position.TurnRight();
        }

        private bool IsInsideArea(Coordinate coordinate)
        {
            if (coordinate.X > Plateau.SizeX ||
                coordinate.Y > Plateau.SizeY ||
                coordinate.X < 0 ||
                coordinate.Y < 0)
                return false;

            return true;
        }


    }
}
