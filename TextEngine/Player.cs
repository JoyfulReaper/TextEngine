/*
 TextEngine: Player.cs
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
    /// Represents the playable character
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Construct a playable character
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="health">Staring health (any int > 0)</param>
        /// <param name="money">Players starting money. Any decimal, can be negative</param>
        public Player(string name = "Player", int health = 100, decimal money = 0) : base(name, health, money) { }
    }
}
