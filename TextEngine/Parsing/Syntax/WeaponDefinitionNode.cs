using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class WeaponDefinitionNode : SyntaxNode
    {
        public WeaponDefinitionNode(string name, Dictionary<string, object> properties)
        {
            Name = name;
            Properties = properties;
        }

        public string Name { get; }
        public Dictionary<string, object> Properties { get; }
    }
}