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
            Room r2 = new Room("Another Room", "Room2", "It smells weird", "I think something might have died");

            r2.SetSide(Direction.Up, new Roof());
            r2.SetSide(Direction.Down, new Floor());
            r2.SetSide(Direction.North, new Wall());
            r2.SetSide(Direction.East, new Wall());
            r2.SetSide(Direction.South, new Wall());
            r2.SetSide(Direction.West, new Exit(r1));

         
            r1.SetSide(Direction.Up, new Roof());
            r1.SetSide(Direction.Down, new Floor());
            r1.SetSide(Direction.North, new Wall());
            r1.SetSide(Direction.East, new Exit(r2));
            r1.SetSide(Direction.South, new Wall());
            r1.SetSide(Direction.West, new Wall());

            if (TextEngine.AddRoom(r1))
                Console.WriteLine("Added: {0}", r1.Name);

            if (TextEngine.AddRoom(r2))
                Console.WriteLine("Added: {0}", r2.Name);

            Item i1 = new Item("Phone", "It's an Android", true, true, 1);

            if (player.inventory.AddItem(i1))
                Console.WriteLine("Added {0}", i1.Name);

            if (player.inventory.AddItem(i1))
                Console.WriteLine("Added {0}", i1.Name);

            if (player.inventory.AddItem(i1, 1))
                Console.WriteLine("Added {0}", i1.Name);
        }
    }
}
