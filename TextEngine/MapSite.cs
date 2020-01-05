using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    public abstract class MapSite
    {
        public string Name { get; set; }

        public abstract void Enter();
    }
}
