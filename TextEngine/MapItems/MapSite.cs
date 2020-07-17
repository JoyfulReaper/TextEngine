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
using System;

namespace TextEngine.MapItems
{
    /// <summary>
    /// Represents a "site" on the "map" can be a Room, Wall, Exit, Floor, Roof, etc which can be entered (or not)
    /// </summary>
    public abstract class MapSite
    {
        /// <summary>
        /// The name of the MapSite
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attempt to enter this MapSite
        /// </summary>
        /// <param name="character">The Character that is entering the MapSite</param>
        /// <param name="heading">The Direction the Character is heading</param>
        public abstract void Enter(Character character, Direction heading);

        /// <summary>
        /// String representation of a MapSite
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{this.GetType().Name}] Name: {Name}";
        }
    }
}
