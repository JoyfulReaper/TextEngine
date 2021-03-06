﻿/*
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
