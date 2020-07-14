/*
 TextEngine: MapSite.cs
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
    public abstract class MapSite
    {
        /// <summary>
        /// The name of the MapSite
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attempt to enter this MapSite
        /// </summary>
        /// <param name="character">The Character that is entering the MapSite</param>
        /// <param name="going"></param>
        public abstract void Enter(Character character, Direction going);

        public override string ToString()
        {
            return $"[{this.GetType().Name}] Name: {Name}";
        }
    }
}
