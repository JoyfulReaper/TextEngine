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
    public enum Direction { North, South, East, West, Up, Down };

    public static class TextEngine
    {
        public static bool GameOver { get; private set; } = false; // The game has ended
        public static bool GameStarted { get; private set; } = true; // The game has begun
        public static Player player; // Active character
        public static Room StartRoom { get; set; } // Starting location

        private static List<MapSite> rooms; // List of rooms
        

        public static bool AddRoom(Room room)
        {
            if (RoomExists(room))
                return false;

            rooms.Add(room);
            return true;
        }

        public static bool RoomExists(Room room) => rooms.Contains(room);
    }
}
