using System;
using MarsRover.Enums;

namespace MarsRover.Models
{
    public class Position
    {
        public Direction Direction { get; set; }
        public Coordinate Coordinate { get; set; }

        public Position(Coordinate coordinate, Direction direction)
        {
            this.Coordinate = coordinate;
            this.Direction = direction;
        }

        public void TurnRight()
        {
            if (this.Direction == Direction.W)
                Direction = Direction.N;
            else
                Direction = Direction + 1;
        }

        public void TurnLeft()
        {
            if (this.Direction == Direction.N)
                Direction = Direction.W;
            else
                Direction = this.Direction - 1;
        }

        public void MoveForward()
        {
            var nextCoordinates = GetNextCoordinate();
            Coordinate = nextCoordinates;
        }

        public Coordinate GetNextCoordinate()
        {
            var coordinate = new Coordinate(Coordinate.X, Coordinate.Y);
            
            switch (Direction)
            {
                case Direction.N:
                    coordinate.Y++;
                    break;
                case Direction.E:
                    coordinate.X++;
                    break;
                case Direction.S:
                    coordinate.Y--;
                    break;
                case Direction.W:
                    coordinate.X--;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return coordinate;
        }

    }
}
