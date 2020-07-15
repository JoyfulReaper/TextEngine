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

namespace TextEngine
{
    /// <summary>
    /// Thrown when trying to use a room that the TextEngine does not know about.
    /// </summary>
    public class RoomDoesNotExisitException : Exception
    {
        public RoomDoesNotExisitException() { }

        public RoomDoesNotExisitException(string message)
            : base(message) { }

        public RoomDoesNotExisitException(string message, Exception inner)
            : base(message, inner) { }
    }

    /// <summary>
    /// Thrown when trying to assign an invalid value to a property
    /// </summary>
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException() { }

        public InvalidQuantityException(string message)
            : base(message) { }

        public InvalidQuantityException(string message, Exception inner)
            : base(message, inner) { }
    }

    /// <summary>
    /// What are Unit tests...??
    /// </summary>
    public class DebugException : Exception
    {
        public DebugException() { }

        public DebugException(string message)
            : base(message) { }

        public DebugException(string message, Exception inner)
            : base(message, inner) { }
    }

    /// <summary>
    /// Don't know if I should use this or ArgumentException...
    /// </summary>
    public class InvalidItemException : Exception
    {
        public InvalidItemException() { }

        public InvalidItemException(string message)
            : base(message) { }

        public InvalidItemException(string message, Exception inner)
            : base(message, inner) { }
    }
}
