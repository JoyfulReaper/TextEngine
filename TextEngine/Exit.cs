using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    class Exit : MapSite
    {
        public string Name { get; set; } = "door";
        public bool isLocked { get; set; } = false;
        public bool isVisible { get; set; } = true;
        private MapSite toRoom;
        public override void Enter()
        {
            throw new NotImplementedException();
        }
    }
}
