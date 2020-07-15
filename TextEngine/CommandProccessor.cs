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
                ProcessCommand($"GO {commandSplit[0]}");

            if (commandSplit[0] == "LOOK")
            {
                ProcessLook(commandSplit);
            }
        }

        private static void ProcessLook(string[] commandSplit)
        {
            if (commandSplit.Length == 1)
                TextEngine.AddMessage(TextEngine.Player.Location.LookDescription);
            return;
        }
    }
}
