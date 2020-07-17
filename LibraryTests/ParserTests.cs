using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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

        [TestMethod]
        public void Parse_Weapon_Should_Pass()
        {
            var src = "weapon \"sword\" with mindamage 10 and maxdamage 35";
            var parser = new Parser();
            var result = parser.Parse(src);
        }

        [TestMethod]
        public void Parse_Many_Should_Pass()
        {
            var src = "include \"base.script\"\nkey \"blub\" with maxusage 10 end\nweapon \"sword\" with mindamage 10 and maxdamage 35 end character \"leo\" with health 100 and money 150 end";
            var parser = new Parser();
            var result = parser.Parse(src);
        }

        [TestMethod]
        public void Parse_Memory_Should_Pass()
        {
            var src = "memory \"name\" equals \"dodo\"";
            var parser = new Parser();
            var result = parser.Parse(src);
        }

        [TestMethod]
        public void Parse_Memory_Empty_Should_Pass()
        {
            var src = "memory \"name\"";
            var parser = new Parser();
            var result = parser.Parse(src);
        }

        [TestMethod]
        public void Parse_EventSubscription_Should_Pass()
        {
            var src = "on \"start\" tell \"hello world\" end";
            var parser = new Parser();
            var result = parser.Parse(src);
        }

        [TestMethod]
        public void Parse_AskFor_Should_Pass()
        {
            var src = "ask for \"name?\" to \"name\"";
            var parser = new Parser();
            var result = parser.Parse(src);
        }
    }
}