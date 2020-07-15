/*
 TextEngine: TextEngine.cs
 Copyright (C) 2020 Kyle Givler
 
 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.
 
 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 GNU General Public License for more details.
 
 You should have received a copy of the GNU General Public License
 along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System;

namespace TextEngine
{
    /// <summary>
    /// Represent the directions the player can move in
    /// </summary>
    public enum Direction { Invalid, North, South, East, West, Up, Down };

    /// <summary>
    /// Static class for keeping track of important information
    /// </summary>
    public static class TextEngine
    {
        /// <value>
        /// Flag indicating if the game has ended
        /// </value>
        public static bool GameOver { get; private set; } = true;

        /// <summary>
        /// The active playable character
        /// </summary>
        public static Player Player { get; set; }

        /// <summary>
        /// The room in which the game should begin
        /// </summary>
        public static Room StartRoom
        {
            get { return startRoom; }
            set 
            {
                if (map.Contains(value))
                {
                    startRoom = value;
                    Player.Location = startRoom;
                    startRoom.Enter(Player, Direction.Invalid);
                }
                else
                    throw new RoomDoesNotExisitException(value.ShortName + " has not been added to the map");
            }
        }

        /// <summary>
        /// List containing all rooms on the map
        /// </summary>
        private static List<MapSite> map = new List<MapSite>();

        private static Queue<string> messages = new Queue<string>();
        private static Room startRoom = null;

        //////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Preform any setup and prepare fot the game to begin
        /// </summary>
        public static void StartGame()
        {
            if (!GameOver)
                throw new InvalidOperationException("A game is in progress");

            if (startRoom == null)
                throw new InvalidOperationException("The starting room has not been set");

            GameOver = false;

            // TODO: Any critical start up such as loading/placing/creating rooms, NPCs, items, ETC
        }

        /// <summary>
        /// Get the name of a direction
        /// </summary>
        /// <param name="dir">Direction to get the name of</param>
        /// <param name="shortName">Return short name susch as "N" instead of "North"</param>
        /// <returns>String containing the name of the direction</returns>
        public static string DirectionName(Direction dir, bool shortName = false)
        {
            switch (dir)
            {
                case Direction.North:
                    if (shortName)
                        return "N";
                    return "North";
                case Direction.East:
                    if (shortName)
                        return "E";
                    return "East";
                case Direction.West:
                    if (shortName)
                        return "W";
                    return "West";
                case Direction.South:
                    if (shortName)
                        return "S";
                    return "South";
                case Direction.Up:
                    return "Up";
                case Direction.Down:
                    return "Down";
                default:
                    return "Unknown Direction";
            }
        }

        public static Direction GetDirectionFromChar(char c)
        {
            switch (c)
            {
                case 'N':
                    return Direction.North;
                case 'S':
                    return Direction.South;
                case 'E':
                    return Direction.East;
                case 'W':
                    return Direction.West;
                case 'U':
                    return Direction.Up;
                case 'D':
                    return Direction.Down;
                default:
                    return Direction.Invalid;
            }
        }

        /// <summary>
        /// Add a room to the map
        /// </summary>
        /// <param name="room">The room to add</param>
        /// <returns>true on success, false on failure</returns>
        public static void AddRoom(Room room)
        {
            if (RoomExists(room))
                throw new ArgumentException(room.ShortName + " already exisits in map");

            map.Add(room);
        }

        /// <summary>
        /// Check if a room exists
        /// </summary>
        /// <param name="room">Room to check for</param>
        /// <returns>true on success, false on failure</returns>
        public static bool RoomExists(Room room) => map.Contains(room);


        public static void ProccessCommand(string command)
        {
            CommandProccessor.ProcessCommand(command);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void AddMessage(string message) => messages.Enqueue(message);

        public static bool HasMessage() => messages.Count > 0;

        public static string GetMessage() => messages.Dequeue();

        //////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}