using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class WeaponDefinitionNode : PropertyOnlyBasedCommand
    {
        public WeaponDefinitionNode(string name, Dictionary<string, object> properties) : base(name, properties)
        {
        }
    }
}