using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TextEngine.Parsing;
using TextEngine.Parsing.Text;

namespace LibraryTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void Lexer_Should_Pass()
        {
            var src = "memoryslot \"name\"\non \"setup\" ask for \"Please Tell me your name: \" to \"name\"";
            var lexer = new Lexer(SourceText.From(src, "tests.script"));

            var tokens = lexer.GetAllTokens();

            foreach (var t in tokens)
            {
                Debug.WriteLine(t);
            }
        }
    }
}