using System.Collections.Generic;

namespace TextEngine.Parsing.Syntax
{
    public class BlockNode : SyntaxNode
    {
        public BlockNode(IEnumerable<SyntaxNode> children)
        {
            Children = children;
        }

        public IEnumerable<SyntaxNode> Children { get; }
    }
}