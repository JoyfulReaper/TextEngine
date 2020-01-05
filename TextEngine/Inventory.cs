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
    class Inventory
    {
        public int Capacity {get; private set;}
        public int Count { get; private set; }
        private List<Item> items;

        public bool AddItem(Item item, int quantity = 1)
        {
            if (Count + quantity > Capacity)
                return false;

            if(items.Contains(item))
            {
                Console.WriteLine("DEBUG: Looking for existing item");
                items.Find(x => x.Name.Contains(item.Name)).Quantity += quantity;
            }

            items.Add(item);

            return true;
        }

        public bool RemoveItem(Item item, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public bool HasItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string name)
        {
            throw new NotImplementedException();
        }

        
    }
}
