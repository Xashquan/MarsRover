using System;
using MarsRover.Helpers;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plateau size:");
            var sizeInput = Console.ReadLine();
            var plateau = CreationHelper.CreatePlateau(sizeInput);
            while (true)
            {
                Console.WriteLine("Rover position:");
                var roverInput = Console.ReadLine();
                var rover = CreationHelper.CreateRover(roverInput);
                plateau.LandRover(rover);

                Console.WriteLine("Rover commands:");
                var commandsInput = Console.ReadLine();
                plateau.MoveRover(rover, commandsInput);

                Console.WriteLine("Do you want to add another rover on this plateau? (Y/N)");
                var addRoverInput = Console.ReadLine();
                if (addRoverInput.ToLower() != "Y")
                    break;

            }

            plateau.LocateRovers();
        }

    }
}
