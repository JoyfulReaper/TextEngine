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
            Count = 0;
        }

        ////////////////////////////////////////////////////////////////////////

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
            if (!items.Contains(item) || quantity > item.Quantity)
                return false;

            item.Quantity -= quantity;

            if (item.Quantity == 0 && !items.Remove(item))
                return false;

            if (items.Contains(item) && item.Quantity <= 0)
                throw new Exception("Something went wrong in RemoveItem(Item item, int quantity");

            return true;
        }

        public bool RemoveItem(String itemName, int quantity = 1)
        {
            Item item = items.Find(x => x.Name.Equals(itemName));
            if (item == null)
                return false;


            return RemoveItem(item);
        }

        public bool HasItem(Item item) => items.Contains(item);

        public bool HasItem(String item)
        {
            return items.Find(x => x.Name.Equals(item)).Equals(null) ? false : true;
        }

        public Item GetItem(string name)
        {
            if (items.Find(x => x.Name.Equals(name)).Equals(null))
                return null;

            return items.Find(x => x.Name.Equals(name));
        }

        
    }
}
