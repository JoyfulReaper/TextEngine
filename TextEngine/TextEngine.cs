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

using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    /// <summary>
    /// Represent the cardnial directions
    /// </summary>
    public enum Direction { North, South, East, West, Up, Down };

    public static class TextEngine
    {
        /// <value>
        /// Flag indicating if the game has ended
        /// </value>
        public static bool GameOver { get; private set; } = false;

        /// <summary>
        /// Flag indicating if the game has started
        /// </summary>
        public static bool GameStarted { get; private set; } = true;

        /// <summary>
        /// The active playable character
        /// </summary>
        public static Player player;

        /// <summary>
        /// The room in which the game should begin
        /// </summary>
        public static Room StartRoom { get; set; }

        /// <summary>
        /// List containing all rooms on the map
        /// </summary>
        private static List<MapSite> map = new List<MapSite>();
        
        /// <summary>
        /// Add a room to the map
        /// </summary>
        /// <param name="room">The room to add</param>
        /// <returns>true on success, false on failure</returns>
        public static bool AddRoom(Room room)
        {
            if (RoomExists(room))
                return false;

            map.Add(room);
            return true;
        }

        /// <summary>
        /// Check if a room exists
        /// </summary>
        /// <param name="room">Room to check for</param>
        /// <returns>true on success, false on failure</returns>
        public static bool RoomExists(Room room) => map.Contains(room);
    }
}
