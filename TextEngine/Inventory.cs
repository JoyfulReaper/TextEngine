/*
 TextEngine: Inventory.cs
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
    public class Inventory
    {
        /// <summary>
        /// The total number of items the inventory can hold
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The current number of items in the inventory
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// A list containing all of the items in the inventory
        /// </summary>
        private List<Item> items;

        public Inventory(int capacity = 1)
        {
            items = new List<Item>();
            Capacity = capacity;
        }

        /// <summary>
        /// Adds an item to the inventory
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <param name="quantity">the number of the item to add</param>
        /// <returns>true on success, false on failure</returns>
        public bool AddItem(Item item, int quantity = 1)
        {
            if (Count + quantity > Capacity)
                return false;

            if (!item.Obtainable)
                return false;

            if(items.Contains(item))
            {
                item.Quantity += quantity;
            }

            items.Add(item);
            Count++;

            return true;
        }

        public bool RemoveItem(Item item, int quantity = 1)
        {
            throw new NotImplementedException();

            if(items.Contains(item))
            {
                if (quantity > 0)
                    return false;
            }
        }

        public bool HasItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string name)
        {
            if (items.Find(x => x.Name.Equals(name)).Equals(null))
                return null;

            return items.Find(x => x.Name.Equals(name));
        }

        
    }
}
