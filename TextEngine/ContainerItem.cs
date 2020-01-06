using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    class ContainerItem : Item
    {
        public bool locked { get; set; }
        public Inventory inventory { get; }

        public ContainerItem(string name, string desc, bool visible, bool obtainable, int cap) : base(name, desc, visible, obtainable) { inventory = new Inventory(cap); }
        public ContainerItem(string name, string desc, bool visible, bool obtainable) : base(name, desc, visible, obtainable) { inventory = new Inventory(); }
        public ContainerItem(string name) : this(name, "", true, true) { inventory = new Inventory(); }
    }
}
