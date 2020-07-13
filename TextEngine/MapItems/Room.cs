/*
 TextEngine: Room.cs
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

namespace TextEngine
{
    /// <summary>
    /// Represents a room with 6 sides, one for each Direction
    /// </summary>
    public class Room : MapSite
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string LookDescription { get; set; }
        public bool Visisted { get; set; }

        public Inventory Inventory { get; }
        private Dictionary<Direction, MapSite> sides;

        public Room(string name, string shortName, string desc, string lookDesc)
        {
            Name = name;
            ShortName = shortName;
            Description = desc;
            LookDescription = lookDesc;
            Visisted = false;
            Inventory = new Inventory();
            sides = new Dictionary<Direction, MapSite>();
        }
        public Room(string name) : this(name, "", "", "") { }

        public override void Enter(Character character, Direction dir)
        {
            Visisted = true;
            TextEngine.Player.Move(this);
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a side of the room
        /// </summary>
        /// <param name="dir">Direction of side to retreive</param>
        /// <returns>MapSite on the side of the room indicated</returns>
        public MapSite GetSide(Direction dir)
        {
            return sides[dir];
        }

        public void SetSide(Direction dir, MapSite site)
        {
            sides[dir] = site;
        }
    }
}
