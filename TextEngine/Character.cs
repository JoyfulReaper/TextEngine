/*
MIT License

Copyright(c) 2020 Kyle Givler

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using TextEngine.MapItems;

namespace TextEngine
{
    /// <summary>
    /// Represents a Character
    /// </summary>
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

        /// <summary>
        /// The maximum health a character can have
        /// </summary>
        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("MaxHealth must be > 0");
                maxHealth = value;
            }
        }

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
        public Wallet CharacterWallet { get; set; }

        /// <summary>
        /// The room that the Character is in
        /// </summary>
        public Room Location { get; set; }

        /// <summary>
        /// The Room that the Character was in previously
        /// </summary>
        public Room PreviousLocation { get; private set; }

        /// <summary>
        /// The Character's Inventory
        /// </summary>
        public Inventory Inventory { get;}

        private int health;
        private int maxHealth;

        /// <summary>
        /// Constructs a Character
        /// </summary>
        /// <param name="name">The Character's name</param>
        /// <param name="health">The Character's initial health</param>
        /// <param name="maxHealth">The Character's maximum health</param>
        public Character(string name = "Character", int health = 100, int maxHealth = 1000)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            CharacterWallet = new Wallet();
            Inventory = new Inventory();
        }
        /// <summary>
        /// Check if the chacater is alive
        /// </summary>
        /// <returns>true if health > 0 other wise false;</returns>
        public virtual bool IsAlive() => Health > 0;

        /// <summary>
        /// Move the Character to another Room
        /// </summary>
        /// <param name="room">The Room to move the character to</param>
        public virtual void Move(Room room)
        {
            Location = room;
            PreviousLocation = Location;
        }

        /// <summary>
        /// A string representation of this Character
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name: {Name}, Description {Description}, Health: {Health}, MaxHealth: {MaxHealth}";
        }
    }
}
