using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Health { get; set; }
        public decimal Money { get; set; }
        private Inventory inventory;

        public virtual bool isAlive() => Health > 0;
    
    }
}
