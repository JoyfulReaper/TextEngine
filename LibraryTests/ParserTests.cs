using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextEngine.Parsing;

namespace LibraryTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Lexer_Should_Pass()
        {
            var src = "go \"left\" and pickup item\ntalk with carl";
            var parser = new Parser();
            var result = parser.Parse(src);
        }
    }
}