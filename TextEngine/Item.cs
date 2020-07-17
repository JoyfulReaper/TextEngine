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

        /// <summary>
        /// The plural name of this item
        /// </summary>
        public string PluralName { get; set; }

        /// <value>The description to be shown for the item</value>
        public string Description { get; set; }

        /// <summary>
        /// Construct an Item
        /// </summary>
        /// <param name="name">Item's Name</param>
        /// <param name="pluralName">Item's plural name</param>
        /// <param name="desc">Item's description</param>
        /// <param name="visible">Determine if the Item is Visible</param>
        /// <param name="obtainable">Determine if the Item can be added to an Inventory</param>
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

        /// <summary>
        /// Construct an Item
        /// </summary>
        /// <param name="name">Item's Name</param>
        /// <param name="pluralName">Item's plural name</param>
        /// <param name="des">Item's description</param>
        public Item(string name, string pluralName, string des) : this(name, null, des, true, true) { }

        /// <summary>
        /// Construct an Item
        /// </summary>
        /// <param name="name">Item's name</param>
        /// <param name="desc">Item's description</param>
        /// <param name="visible">Is the Item visible?</param>
        /// <param name="obtainable">Can the Item be added to an Inventory?</param>
        public Item(string name, string desc, bool visible, bool obtainable) : this(name, null, desc, visible, obtainable) { }

        /// <summary>
        /// Construct an Item
        /// </summary>
        /// <param name="name">Item's name</param>
        /// <param name="des">Item's description</param>
        public Item(string name, string des) : this(name, null, des, true, true) { }

        /// <summary>
        /// Construct an Item
        /// </summary>
        /// <param name="name">The name of the Item</param>
        public Item(string name) : this(name, "") { }

        /// <summary>
        /// Use this item
        /// </summary>
        public virtual void Use()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if this item is equal to another item
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if equal</returns>
        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   Obtainable == item.Obtainable &&
                   Visible == item.Visible &&
                   Name == item.Name &&
                   Description == item.Description;
        }

        /// <summary>
        /// Get this Item's hashcode
        /// </summary>
        /// <returns>Item's hashcode</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Obtainable, Visible, Name, Description);
        }

        /// <summary>
        /// A String representation of this Item
        /// </summary>
        /// <returns>A String representation of this Item</returns>
        public override string ToString()
        {
            return "Name: " + Name + ", Plural name " + PluralName + ", Description: " + Description + ", Visible: " + Visible + ", Obtainable: " + Obtainable;
        }
    }
}
