using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextEngine.Parsing;

namespace LibraryTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Parse_Character_Should_Pass()
        {
            var src = "character \"leo\" with health 100 and money 150";
            var parser = new Parser();
            var result = parser.Parse(src);
        }
    }
}