/*
MIT License

Copyright(c) 2020 Kyle Givler

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using TextEngine.MapItems;

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
                ProcessGo(commandSplit);
                return;
            }

            TextEngine.AddMessage("I don't understand :(");
        }

        private static void ProcessGo(string[] commandSplit)
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
