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
using System.Linq;

namespace TextEngine
{
    public class Inventory
    {
        /// <summary>
        /// The total number of items the inventory can hold
        /// </summary>
        public int Capacity 
        {
            get => capacity;
            set 
            {
                if (value < 0)
                    throw new InvalidQuantityException("Inventory Capacity must be >= 0");
                else
                    capacity = value;
            }
        }

        /// <summary>
        /// The current number of items in the inventory
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// A list containing all of the items in the inventory
        /// </summary>
        private Dictionary<Item, int> items;
        private int capacity;

        public Inventory(int capacity = 1)
        {
            items = new Dictionary<Item, int>();
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
        public void AddItem(Item item, int quantity = 1)
        {
            if (Count + quantity > Capacity)
                throw new InvalidQuantityException("Inventory can not hold that many itmes");

            if (!item.Obtainable)
                throw new InvalidOperationException(item.Name + " is not obtainable!");

            if (items.ContainsKey(item))
                items[item] += quantity;

            if (!HasItem(item))
                items.Add(item, quantity);

            Count += quantity;
        }

        public bool AddItem(String item, int quantity = 1)
        {
            throw new NotImplementedException("Later, when we can load items from files, I promise!");
        }

        public void RemoveItem(Item item, int quantity = 1)
        {
            if (!items.ContainsKey(item))
                throw new ArgumentException("Iventory does not contain " + item.Name);

            if (quantity > items[item])
                throw new ArgumentException("Inventory does not have " + quantity + " items. It has: " + items[item]);

            items[item] -= quantity; // The magic happens here!

            if (items[item] == 0 && !items.Remove(item))
                throw new DebugException(item.Name + " quantity is 0, but we can't remove it!");

            if (items.ContainsKey(item) && items[item] <= 0)
                throw new DebugException(item.Name + " quantity is 0, but it wasn't removed!");
        }

        public void RemoveItem(String itemName, int quantity = 1)
        {
            if (!HasItem(itemName))
                throw new ArgumentException("Iventory does not contain " + itemName);

            RemoveItem(GetItem(itemName));
        }

        public bool HasItem(Item item) => items.ContainsKey(item);

        public bool HasItem(String itemName) => items.Keys.Any(key => key.Name == itemName);

        public Item GetItem(string name)
        {
            if (!HasItem(name))
                throw new ArgumentException(name + " is not in the inventory");

            return items.Keys.First(key => key.Name == name);
        }

        public int ItemQuantity(Item item) => items[item];

        public int ItemQuantity(string itemName)
        {
            if (!HasItem(itemName))
                throw new ArgumentException("Inventoy does not contain " + itemName);

            return items[GetItem(itemName)];
        }
    }
}
