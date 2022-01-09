using FluentAssertions;
using MarsRover.Enums;
using MarsRover.Helpers;
using MarsRover.Models.RoverCommands;
using Xunit;

namespace MarsRover.Test
{
    public class CommandTests
    {
        [Fact]
        public void TurnLeftTest()
        {
            var plateau = CreationHelper.CreatePlateau("5 5");
            var rover = CreationHelper.CreateRover("2 3 N");
            plateau.LandRover(rover);
            rover.Move(new TurnLeftCommand());
            
            var roverPosition = rover.GetPosition();

            Assert.Equal(Direction.W, roverPosition.Direction);
            Assert.Equal(2, roverPosition.Coordinate.X);
            Assert.Equal(3, roverPosition.Coordinate.Y);
        }

        [Fact]
        public void TurnRightTest()
        {
            var plateau = CreationHelper.CreatePlateau("5 5");
            var rover = CreationHelper.CreateRover("2 3 N");
            plateau.LandRover(rover);
            rover.Move(new TurnRightCommand());

            var roverPosition = rover.GetPosition();

            Assert.Equal(Direction.E, roverPosition.Direction);
            Assert.Equal(2, roverPosition.Coordinate.X);
            Assert.Equal(3, roverPosition.Coordinate.Y);
        }

        [Fact]
        public void MoveForwardTest()
        {
            var plateau = CreationHelper.CreatePlateau("5 5");
            var rover = CreationHelper.CreateRover("2 3 N");
            plateau.LandRover(rover);
            rover.Move(new MoveForwardCommand());

            var roverPosition = rover.GetPosition();

            Assert.Equal(2, roverPosition.Coordinate.X);
            Assert.Equal(4, roverPosition.Coordinate.Y);
            Assert.Equal(Direction.N, roverPosition.Direction);
        }

        [Fact]
        public void OutOfAreaTest()
        {
            var plateau = CreationHelper.CreatePlateau("5 5");
            var rover = CreationHelper.CreateRover("4 5 N");
            plateau.LandRover(rover);
            rover.Move(new MoveForwardCommand());

            var roverPosition = rover.GetPosition();

            Assert.Equal(4, roverPosition.Coordinate.X);
            Assert.Equal(5, roverPosition.Coordinate.Y);
            Assert.Equal(Direction.N, roverPosition.Direction);
        }
    }
}
