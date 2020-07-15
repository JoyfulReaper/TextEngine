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
            Lexer lex = new Lexer(SourceText.From("This is some text\nMore Text\nthis is a number 1 2 3\nis \"This\" a string?"));
            IEnumerable<Token> tokens = lex.GetAllTokens();

            foreach (var t in tokens)
                Console.WriteLine(t);
        }
    }
}
