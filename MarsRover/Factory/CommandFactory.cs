using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Models.RoverCommands;

namespace MarsRover.Factory
{
    public static class CommandFactory
    {
        public static List<IRoverCommand> CommandBuilder(string commands)
        {
            return commands.ToUpper()
                .ToCharArray()
                .Select(CreateCommand)
                .ToList();
        }

        private static IRoverCommand CreateCommand(char c)
        {
            return c switch
            {
                'L' => new TurnLeftCommand(),
                'R' => new TurnRightCommand(),
                'M' => new MoveForwardCommand(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
