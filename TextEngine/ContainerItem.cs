/*
 TextEngine: ContainerItem.cs
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
    /// An item that has an inventory (Like a chest)
    /// </summary>
    class ContainerItem : Item
    {
        public bool locked { get; set; }
        public Inventory inventory { get; }

        public ContainerItem(string name, string desc, bool visible, bool obtainable, int cap) : base(name, desc, visible, obtainable) { inventory = new Inventory(cap); }
        public ContainerItem(string name, string desc, bool visible, bool obtainable) : base(name, desc, visible, obtainable) { inventory = new Inventory(); }
        public ContainerItem(string name) : this(name, "", true, true) { inventory = new Inventory(); }
    }
}
