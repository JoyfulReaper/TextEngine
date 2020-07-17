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
    /// Reprensents the MapSite in the Down direction, the Floor
    /// </summary>
    public class Floor : MapSite
    {
        /// <summary>
        /// Construct a Floor
        /// </summary>
        /// <param name="name">The name of the Floor</param>
        public Floor(string name = "floor") => Name = name;

        /// <summary>
        /// Attempt to enter this floor
        /// </summary>
        /// <param name="character">The Character entering</param>
        /// <param name="heading">The Character's heading</param>
        public override void Enter(Character character, Direction heading)
        {
            TextEngine.AddMessage("You try to go " + TextEngine.DirectionName(heading) + ", but you can't get through the " + Name);
        }
    }
}
