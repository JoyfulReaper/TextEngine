using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine
{
    public class Room : MapSite
    {
        private Inventory inventory;
        private Dictionary<Direction,MapSite> sides;
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string LookDescription { get; set; }
        public bool Visisted { get; set; }

        public Room(string name) => Name = name;
        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public MapSite getSide(Direction dir)
        {
            return sides[dir];
        }

        public void SetSide(Direction dir, MapSite site)
        {
            sides[dir] = site;
        }
    }
}
