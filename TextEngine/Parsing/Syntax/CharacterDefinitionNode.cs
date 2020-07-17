using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class CharacterDefinitionNode : PropertyOnlyBasedCommand
    {
        public CharacterDefinitionNode(string name, Dictionary<string, object> properties) : base(name, properties)
        {
        }
    }
}