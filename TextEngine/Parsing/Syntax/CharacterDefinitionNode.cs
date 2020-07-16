﻿using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class CharacterDefinitionNode : SyntaxNode
    {
        public CharacterDefinitionNode(string name, Dictionary<string, object> properties)
        {
            Name = name;
            Properties = properties;
        }

        public string Name { get; }
        public Dictionary<string, object> Properties { get; }
    }
}