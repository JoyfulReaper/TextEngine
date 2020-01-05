/*
 TextEngine: Exit.cs
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


namespace TextEngine
{
    /// <summary>
    /// Represents and exit from one MapSite to another
    /// </summary>
    public class Exit : MapSite
    {
        /// <summary>
        /// The name of the exit
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Weather or not the exit is locked
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Weather or not the exit is visible 
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// The Mapsite on the other side of the exit
        /// </summary>
        public MapSite ToRoom { get; set; }

        public Exit(string name, MapSite toRoom, bool locked, bool visible)
        {
            Name = name;
            ToRoom = toRoom;
            Locked = locked;
            Visible = visible;
        }

        /// <summary>
        /// Create an exit
        /// </summary>
        /// <param name="toRoom">The MapSite on the other side of the exit</param>
        public Exit(MapSite toRoom) : this("door", null, false, true) { }

        public override void Enter(Character character, Direction going)
        {
            throw new NotImplementedException();
        }

    }
}
