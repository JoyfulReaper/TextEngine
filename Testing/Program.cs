using System;
using System.Collections.Generic;
using TextEngine.Parsing;
using TextEngine.Parsing.Text;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type something: ");
            Lexer lex = new Lexer(SourceText.From(Console.ReadLine()));
            IEnumerable<Token> tokens = lex.GetAllTokens();

            foreach (var t in tokens)
                Console.WriteLine(t);

            var src = "go \"north\"";
            var parser = new Parser();
            var result = parser.Parse(src);
        }
    }
}
