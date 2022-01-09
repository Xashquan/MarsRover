using System;
using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Utils;

namespace MarsRover.Helpers
{
    public static class CreationHelper
    {
        public static Plateau CreatePlateau(string input)
        {
            var inputArray = input.Split(" ");
            if (inputArray.Length != 2)
                throw new ArgumentException();

            return new Plateau(Convert.ToInt32(inputArray[0]), Convert.ToInt32(inputArray[1]));
        }

        public static Rover CreateRover(string input)
        {
            var inputArray = input.Split(" ");
            if (inputArray.Length != 3)
                throw new ArgumentException();

            var x = Convert.ToInt32(inputArray[0]);
            var y = Convert.ToInt32(inputArray[1]);
            var direction = inputArray[2].ToUpper().ToEnum<Direction>();

            return new Rover(new Position(new Coordinate(x, y), direction));
        }
    }
}
