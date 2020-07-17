namespace TextEngine.Parsing.Syntax
{
    public class LiteralNode : SyntaxNode
    {
        public LiteralNode(object value)
        {
            Value = value;
        }

        public object Value { get; }
    }
}