using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class AskForInputNode : SyntaxNode
    {
        public AskForInputNode(string message, string slotName)
        {
            Message = message;
            SlotName = slotName;
        }

        public string Message { get; }
        public string SlotName { get; }
    }
}