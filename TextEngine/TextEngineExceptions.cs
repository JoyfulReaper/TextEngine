using System;
using System.Collections.Generic;
using System.Text;

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
}
