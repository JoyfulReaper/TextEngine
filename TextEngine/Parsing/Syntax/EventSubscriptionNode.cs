namespace TextEngine.Parsing.Syntax
{
    public class EventSubscriptionNode : SyntaxNode
    {
        public EventSubscriptionNode(string name, BlockNode body)
        {
            Name = name;
            Body = body;
        }

        public string Name { get; }
        public BlockNode Body { get; }
    }
}