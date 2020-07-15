// This will be an attempt to use Writing a Text Adventrure Engine in C#
// Inspired by my really bad attempt in c++ 6 years ago :)

using System;
using Kgivler;

namespace TextEngine
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Player player = new Player("Kyle");
            TextEngine.Player = player;
            player.Inventory.Capacity = 100;
            
            Room r1 = new Room("New Room!", "room1", "An empty room", "It looks like there is an exit to the East!");
            Room r2 = new Room("Another Room", "Room2", "It smells weird", "I think something might have died in here!");

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

            TextEngine.AddRoom(r1);
            Console.WriteLine("Added: {0}", r1.Name);

            if (TextEngine.RoomExists(r2))
                Console.WriteLine("r2 is there!");
            else
                Console.WriteLine("r2 is missing!");

            TextEngine.AddRoom(r2);
            Console.WriteLine("Added: {0}", r2.Name);

            if (TextEngine.RoomExists(r2))
                Console.WriteLine("r2 is there!");

            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine(r1.GetSide(Direction.Up).ToString());
            Console.WriteLine(r1.GetSide(Direction.Down).ToString());
            Console.WriteLine(r2.GetSide(Direction.West).ToString());
            Console.WriteLine(r2.GetSide(Direction.East).ToString());
            Console.WriteLine(r2);

            Console.WriteLine("----------------------------------------------------");


            if (!TextEngine.Player.Inventory.HasItem("Phone"))
                Console.WriteLine("Player has no phone!");

            Item i1 = new Item("Phone", "It's an Android", true, true);

            player.Inventory.AddItem(i1);
            Console.WriteLine("Added {0} to player", i1.Name);

            if (TextEngine.Player.Inventory.HasItem("Phone"))
                Console.WriteLine("You have {0} phone.", player.Inventory.ItemQuantity("Phone"));

            r1.Inventory.AddItem(i1);
            Console.WriteLine("Added {0} to room", i1.Name);

            if (TextEngine.Player.Inventory.HasItem("Phone"))
                Console.WriteLine("You have {0} phone.", player.Inventory.ItemQuantity("Phone"));

            player.Inventory.AddItem(i1, 1);
            Console.WriteLine("Added {0}", i1.Name);

            TextEngine.Player.Inventory.AddItem(i1);

            if (TextEngine.Player.Inventory.HasItem("Phone"))
                Console.WriteLine("You have {0} phone.", player.Inventory.ItemQuantity("Phone"));

            Console.WriteLine(i1.ToString());

            GreedyWrap wrapper = new GreedyWrap(Console.WindowWidth);
            TextEngine.StartRoom = r1;
            TextEngine.StartGame();
            while(!TextEngine.GameOver)
            {
                wrapper.LineWidth = Console.WindowWidth;
                while(TextEngine.HasMessage())
                {
                    Console.WriteLine( wrapper.LineWrap((TextEngine.GetMessage() ) ) );
                }

                Console.Write("Enter command: ");
                string input = Console.ReadLine();
                TextEngine.ProccessCommand(input);
                if (input.ToUpper() == "QUIT")
                    Environment.Exit(0);
            }
        }
        public static void TestingSetup()
        {

        }
    }
}
