using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    public class Roof : MapSite
    {
        public string Name { get; set; }
        public Roof(string name) => Name = name;

        public override void Enter()
        {
            throw new NotImplementedException();
        }
    }
}
