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
using System.Collections.Generic;
using System.Linq;

namespace TextEngine
{
    /// <summary>
    /// Represents an Inventory of Items
    /// </summary>
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
        private readonly Dictionary<Item, int> items;
        private int capacity;

        /// <summary>
        /// Construct an Inventory
        /// </summary>
        /// <param name="capacity">initial capacity</param>
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

        /// <summary>
        /// Add Item to Inventory
        /// </summary>
        /// <param name="item">The Item to add</param>
        /// <param name="quantity">The quantity to add</param>
        /// <returns>throws an exception for now :(</returns>
        public bool AddItem(String item, int quantity = 1)
        {
            throw new NotImplementedException("Later, when we can load items from files, I promise!");
        }

        /// <summary>
        /// Remove an Item from the Inventory
        /// </summary>
        /// <param name="item">The Item to remove</param>
        /// <param name="quantity">The quantity to remove</param>
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

        /// <summary>
        /// Remove an item from the Inventory
        /// </summary>
        /// <param name="itemName">The name of the item to remove</param>
        /// <param name="quantity">The quantity to remove</param>
        public void RemoveItem(String itemName, int quantity = 1)
        {
            if (!HasItem(itemName))
                throw new ArgumentException("Iventory does not contain " + itemName);

            RemoveItem(GetItem(itemName));
        }

        /// <summary>
        /// Check if the Iventory contains an item
        /// </summary>
        /// <param name="item">The item to check for</param>
        /// <returns>true if the item is contained, false if not</returns>
        public bool HasItem(Item item) => items.ContainsKey(item);

        /// <summary>
        /// Check if the Inventory contains an Item
        /// </summary>
        /// <param name="itemName">The Item to check for</param>
        /// <returns>True if contained, false otherwise</returns>
        public bool HasItem(String itemName) => items.Keys.Any(key => key.Name == itemName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Item to get</param>
        /// <returns>The Item</returns>
        public Item GetItem(string name)
        {
            if (!HasItem(name))
                throw new ArgumentException(name + " is not in the inventory");

            return items.Keys.First(key => key.Name == name);
        }

        /// <summary>
        /// Check how many of an Item are in the Inventory
        /// </summary>
        /// <param name="item">The item to check for</param>
        /// <returns>The number of that item in the Inventory</returns>
        public int ItemQuantity(Item item) => items[item];

        /// <summary>
        /// Check how many of an Item are in the Inventory
        /// </summary>
        /// <param name="itemName">The name of the Item to check</param>
        /// <returns>The number of that item in the Inventory</returns>
        public int ItemQuantity(string itemName)
        {
            if (!HasItem(itemName))
                throw new ArgumentException("Inventoy does not contain " + itemName);

            return items[GetItem(itemName)];
        }
    }
}
