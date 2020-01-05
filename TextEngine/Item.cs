/*
 TextEngine: Item.cs
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
    /// <summary>
    /// Represents an item
    /// </summary>
    public class Item
    {
        /// <value>Allows the item to be added to an Inventory</value>
        public bool Obtainable { get; set; }
        /// <value>If true the object is visible when looking</value>
        public bool Visible { get; set; }
        /// <value>The name of the item</value>
        public string Name { get; set; }
        /// <value>The description to be shown for the item</value>
        public string Description { get; set; }
        /// <value>The Quantity of the item</value>
        public int Quantity { get; set; }

        public Item(string name, string desc, bool visible, bool obtainable, int quantity)
        {
            Name = name; 
            Description = desc;
            Visible = visible;
            Obtainable = obtainable;

            if (quantity < 1)
                throw new ArgumentOutOfRangeException("Quantity must be > 0");
            else
                Quantity = quantity;
        }
        public Item(string name, string desc, bool visible, bool obtainable) : this(name, desc, true, true, 1) { }
        public Item(string name) : this(name, "", true, true) { }

        public virtual void Use()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   Obtainable == item.Obtainable &&
                   Visible == item.Visible &&
                   Name == item.Name &&
                   Description == item.Description &&
                   Quantity == item.Quantity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Obtainable, Visible, Name, Description, Quantity);
        }
    }
}
