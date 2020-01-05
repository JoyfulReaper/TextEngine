// This will be an attempt to use Writing a Text Adventrure Engine in C#
// Inspired by my really bad attempt in c++ 6 years ago :)

using System;

namespace TextEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Kyle");
            Console.WriteLine("Player: {0}", player.Name);

            Room r1 = new Room("New Room!");
            r1.SetSide(Direction.Up, new Roof());
            r1.SetSide(Direction.Down, new Floor());
            r1.SetSide(Direction.North, new Wall());
            r1.SetSide(Direction.East, new Wall());
            r1.SetSide(Direction.South, new Wall());
            r1.SetSide(Direction.West, new Exit());

            //TextEngine

            Console.WriteLine("Room: {0}", r1.Name);
        }
    }
}
