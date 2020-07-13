using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(string name) : base(name) { }
    }
}
