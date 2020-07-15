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
        /// Weather or not the exit is locked
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Weather or not the exit is visible 
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// The Room on the other side of the exit
        /// </summary>
        public Room ToRoom { get; set; }

        public Exit(string name, Room toRoom, bool locked, bool visible)
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
        public Exit(Room toRoom) : this("door", toRoom, false, true) { }

        public override void Enter(Character character, Direction going)
        {
            if (!Locked)
                ToRoom.Enter(character, going);
            else
                TextEngine.AddMessage("You try to go though the " + Name + ", but it is locked.");

        }

        public override string ToString()
        {
            return base.ToString() + $", toRoom: {ToRoom.ShortName}, Locked {Locked}, Visible {Visible}";
        }

    }
}
