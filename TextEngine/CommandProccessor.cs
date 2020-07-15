using System;
using System.Collections.Generic;
using System.Text;

// This is probably poop, but its a start?

namespace TextEngine
{
    public static class CommandProccessor
    {
        public static void ProcessCommand(string command)
        {
            command = command.Trim();
            var commandSplit = command.ToUpper().Split(" ");

            if (commandSplit[0] == "N" || commandSplit[0] == "S" || commandSplit[0] == "E" || commandSplit[0] == "W" || commandSplit[0] == "U" || commandSplit[0] == "D")
            {
                ProcessCommand($"GO {commandSplit[0]}");
                return;
            }

            if (commandSplit[0] == "LOOK")
            {
                ProcessLook(commandSplit);
                return;
            }

            if(commandSplit[0] == "GO")
            {
                processGo(commandSplit);
                return;
            }

            TextEngine.AddMessage("I don't understand :(");
        }

        private static void processGo(string[] commandSplit)
        {
            if (commandSplit.Length == 1)
                TextEngine.AddMessage("You need to give a direction! Like: Go North");

            Direction going = TextEngine.GetDirectionFromChar(commandSplit[1][0]);
            if (going == Direction.Invalid)
                TextEngine.AddMessage($"{commandSplit[1]} is not a valid direction!");

            MapSite atGoing = TextEngine.Player.Location.GetSide(going);
            atGoing.Enter(TextEngine.Player, going);
        }

        private static void ProcessLook(string[] commandSplit)
        {
            if (commandSplit.Length == 1)
                TextEngine.AddMessage(TextEngine.Player.Location.LookDescription);
            return;
        }
    }
}
