using MarsRover.Enums;
using MarsRover.Helpers;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTests
    {
        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", 1, 3, Direction.N)]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", 5, 1, Direction.E)]
        public void RoverTest(string plateuSize, string position, string commands, int targetX, int targetY, Direction targetDirection)
        {
            var plateau = CreationHelper.CreatePlateau(plateuSize);
            var rover = CreationHelper.CreateRover(position);
            plateau.LandRover(rover);
            plateau.MoveRover(rover, commands);
            var roverPosition = rover.GetPosition();
            Assert.Equal(targetX, roverPosition.Coordinate.X);
            Assert.Equal(targetY, roverPosition.Coordinate.Y);
            Assert.Equal(targetDirection, roverPosition.Direction);
        }
    }
}
