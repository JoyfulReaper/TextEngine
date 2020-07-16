using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public abstract class PropertyOnlyBasedCommand : SyntaxNode
    {
        public PropertyOnlyBasedCommand(string name, Dictionary<string, object> properties)
        {
            Name = name;
            Properties = properties;
        }

        public string Name { get; }
        public Dictionary<string, object> Properties { get; }
    }
}