using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    class Floor : MapSite
    {
        public string Name { get; set; }
        public Floor(string name) => Name = name;

        public override void Enter()
        {
            throw new NotImplementedException();
        }
    }
}
