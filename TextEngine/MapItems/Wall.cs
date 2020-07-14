/*
 TextEngine: Wall.cs
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
    /// Represents a wall
    /// </summary>
    public class Wall : MapSite
    {
        /// <summary>
        /// Wall Constructor
        /// </summary>
        /// <param name="name">name of the wall</param>
        public Wall(string name = "wall") => Name = name;

        public override void Enter(Character character, Direction going)
        {
            TextEngine.AddMessage("You try to go " + TextEngine.DirectionName(going) + ", but you just bump your head on the " + Name);
        }
    }
}
