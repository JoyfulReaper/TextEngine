using System;
using TextEngine.Parsing;

namespace TreePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write(">> ");
                var input = Console.ReadLine();
                var parser = new Parser();
                var tree = parser.Parse(input);
                SyntaxNode.PrettyPrint(tree);
            }
        }
    }
}