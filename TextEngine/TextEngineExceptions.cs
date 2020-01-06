/*
 TextEngine: TextEngineExceptions.cs
 Copyright (C) 2020 Kyle Givler
 
 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.
 
 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 GNU General Public License for more details.
 
 You should have received a copy of the GNU General Public License
 along with this program. If not, see <http://www.gnu.org/licenses/>.
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
