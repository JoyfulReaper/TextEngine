namespace TextEngine.Parsing.Syntax
{
    public class MemorySlotDefinition : SyntaxNode
    {
        public MemorySlotDefinition(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public object Value { get; }
    }
}