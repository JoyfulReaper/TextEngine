/*
 TextEngine: Character.cs
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
    public abstract class Character
    {
        /// <summary>
        /// Character's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Characters Description
        /// </summary> 
        public string Description { get; set; }

        public int MaxHealth { get; set; }

        /// <summary>
        /// Health can be any vaild int > 0. I would suggest using 0 - 100. 0 is dead
        /// </summary>
        public virtual int Health 
        {
            get => health;
            set
            {
                if (value < 0)
                    health = 0;
                else if (health > MaxHealth)
                    health = MaxHealth;
                else
                    health = value;
            }
        }

        /// <summary>
        /// The amount of local currence that the character has
        /// </summary>
        public decimal Money { get; set; }

        public Room Location { get; set; }

        public Room PreviousLocation { get; private set; }

        public Inventory Inventory { get;}

        private int health;

        public Character(string name = "Character", int health = 100, decimal money = 0)
        {
            Name = name;
            Health = health;
            Money = money;
            Inventory = new Inventory();
        }
        /// <summary>
        /// Check if the chacater is alive
        /// </summary>
        /// <returns>true if health > 0 other wise false;</returns>
        public virtual bool IsAlive() => Health > 0;

        public virtual void Move(Room room)
        {
            Location = room;
            PreviousLocation = Location;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Health: " + Health + " Money: " + Money;
        }
    }
}
