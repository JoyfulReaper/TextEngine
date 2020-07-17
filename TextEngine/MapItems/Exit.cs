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

namespace TextEngine.MapItems
{
    /// <summary>
    /// Represents and exit from one MapSite to another
    /// </summary>
    public class Exit : MapSite
    {
        /// <summary>
        /// Weather or not the exit is locked
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Weather or not the exit is visible 
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// The Room on the other side of the exit
        /// </summary>
        public Room ToRoom { get; set; }

        /// <summary>
        /// Construct an Exit
        /// </summary>
        /// <param name="name">The name of the Exit</param>
        /// <param name="toRoom">The room that the Exit leads to</param>
        /// <param name="locked">Whether or not the Exit is locked</param>
        /// <param name="visible">Whether or not the Exit is visible</param>
        public Exit(string name, Room toRoom, bool locked, bool visible)
        {
            Name = name;
            ToRoom = toRoom;
            Locked = locked;
            Visible = visible;
        }

        /// <summary>
        /// Create an exit
        /// </summary>
        /// <param name="toRoom">The MapSite on the other side of the exit</param>
        public Exit(Room toRoom) : this("door", toRoom, false, true) { }

        /// <summary>
        /// Attempt to Enter (Use) this exit
        /// </summary>
        /// <param name="character">The Character attempting to use this Exit</param>
        /// <param name="heading">The Character's heading</param>
        public override void Enter(Character character, Direction heading)
        {
            if (!Locked)
                ToRoom.Enter(character, heading);
            else
                TextEngine.AddMessage("You try to go though the " + Name + ", but it is locked.");

        }

        /// <summary>
        /// A string representation of this Exit
        /// </summary>
        /// <returns>A string representation of this Exit</returns>
        public override string ToString()
        {
            return base.ToString() + $", toRoom: {ToRoom.ShortName}, Locked {Locked}, Visible {Visible}";
        }

    }
}
