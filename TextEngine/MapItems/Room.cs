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
        /// <summary>
        /// The Short Name for this room. May possible show this when the room is entered, have not decided.
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// The Room's description, to be shown when the room is Entered
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The desciption shows when the LOOK command is given
        /// </summary>
        public string LookDescription { get; set; }
        /// <summary>
        /// True if the Character has been in the room before, false is not
        /// </summary>
        public bool Visisted { get; private set; }

        /// <summary>
        /// The Items contained in the Room's Inventory
        /// </summary>
        public Inventory Inventory { get; } // Should we allow this to be set as well?
        private readonly Dictionary<Direction, MapSite> sides;

        /// <summary>
        /// Construct a Room
        /// </summary>
        /// <param name="name">The Room's name</param>
        /// <param name="shortName">The Room's short name</param>
        /// <param name="desc">The description shown when entering the room</param>
        /// <param name="lookDesc">The description shown when issuing the LOOK command</param>
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
        /// <summary>
        /// Construct a Room
        /// </summary>
        /// <param name="name">The name of the Room</param>
        public Room(string name) : this(name, "", "", "") { }

        /// <summary>
        /// Construct a Rooom
        /// </summary>
        /// <param name="name">The Name of the room</param>
        /// <param name="shortName">The short name of the room</param>
        public Room(string name, string shortName) : this(name, shortName, "", "") { }

        /// <summary>
        /// Enter the room
        /// </summary>
        /// <param name="character">The Character entering the room</param>
        /// <param name="heading">The Character's heading</param>
        public override void Enter(Character character, Direction heading)
        {
            if(character == TextEngine.Player)
                Visisted = true;

            character.Move(this);
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

        /// <summary>
        /// Set the MapSite on the side of the room at the given Direction
        /// </summary>
        /// <param name="dir">The Direction of the room to add the side at (ex: Add a wall to the east)</param>
        /// <param name="site">The MapSite to add at the given Direction</param>
        public void SetSide(Direction dir, MapSite site)
        {
            sides[dir] = site;
        }

        /// <summary>
        /// A String representation of this Room
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $", ShortName: {ShortName}, Description {Description}, LookDescription: {LookDescription}, Visited: {Visisted}";
        }
    }
}
