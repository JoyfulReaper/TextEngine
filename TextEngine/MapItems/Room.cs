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

using System.Collections.Generic;

namespace TextEngine.MapItems
{
    /// <summary>
    /// Represents a room with 6 sides, one for each Direction
    /// </summary>
    public class Room : MapSite
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string LookDescription { get; set; }
        public bool Visisted { get; set; }

        public Inventory Inventory { get; }
        private Dictionary<Direction, MapSite> sides;

        public Room(string name, string shortName, string desc, string lookDesc)
        {
            Name = name;
            ShortName = shortName;
            Description = desc;

            if (lookDesc == null || lookDesc.Length <= 0)
                if (Description != null && Description.Length >= 1)
                    LookDescription = Description;
                else
                    LookDescription = "You look around, but don't see anything of any significance";
            else
                LookDescription = lookDesc;

            Visisted = false;
            Inventory = new Inventory();
            sides = new Dictionary<Direction, MapSite>();
        }
        public Room(string name) : this(name, "", "", "") { }

        public Room(string name, string shortName) : this(name, shortName, "", "") { }

        public override void Enter(Character character, Direction dir)
        {
            Visisted = true;
            TextEngine.Player.Move(this);
            TextEngine.AddMessage(Description);
        }
        /// <summary>
        /// Get a side of the room
        /// </summary>
        /// <param name="dir">Direction of side to retreive</param>
        /// <returns>MapSite on the side of the room indicated</returns>
        public MapSite GetSide(Direction dir)
        {
            return sides[dir];
        }

        public void SetSide(Direction dir, MapSite site)
        {
            sides[dir] = site;
        }

        public override string ToString()
        {
            return base.ToString() + $", ShortName: {ShortName}, Description {Description}, LookDescription: {LookDescription}, Visited: {Visisted}";
        }
    }
}
