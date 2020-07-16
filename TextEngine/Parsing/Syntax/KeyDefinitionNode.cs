using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class KeyDefinitionNode : PropertyOnlyBasedCommand
    {
        public KeyDefinitionNode(string name, Dictionary<string, object> properties) : base(name, properties)
        {
        }
    }
}