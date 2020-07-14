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

        public string PluralName { get; set; }

        /// <value>The description to be shown for the item</value>
        public string Description { get; set; }

        public Item(string name, string pluralName, string desc, bool visible, bool obtainable)
        {
            Name = name;
            if (pluralName == null || pluralName.Length <= 0)
                PluralName = name + "s";
            else
                PluralName = pluralName;
            Description = desc;
            Visible = visible;
            Obtainable = obtainable;
        }

        public Item(string name, string pluralName, string des) : this(name, null, des, true, true) { }
        public Item(string name, string desc, bool visible, bool obtainable) : this(name, null, desc, visible, obtainable) { }
        public Item(string name, string des) : this(name, null, des, true, true) { }
        public Item(string name) : this(name, "") { }

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
                   Description == item.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Obtainable, Visible, Name, Description);
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Plural name " + PluralName + ", Description: " + Description + ", Visible: " + Visible + ", Obtainable: " + Obtainable;
        }
    }
}
