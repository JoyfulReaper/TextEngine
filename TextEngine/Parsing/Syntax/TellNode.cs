using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class TellNode : SyntaxNode
    {
        public TellNode(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}