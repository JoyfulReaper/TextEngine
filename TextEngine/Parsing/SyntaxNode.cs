using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TextEngine.Parsing.Syntax;
using TextEngine.Parsing.Text;

namespace TextEngine.Parsing
{
    public abstract class SyntaxNode
    {

        public virtual TextSpan Span
        {
            get
            {
                var children = GetChildren();
                if (children.Any())
                {
                    var first = children.First().Span;
                    var last = children.Last().Span;

                    return TextSpan.FromBounds(first.Start, last.End);
                }

                return TextSpan.FromBounds(0, 0);
            }
        }

        public IEnumerable<SyntaxNode> GetChildren()
        {
            var result = new List<SyntaxNode>();

            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (typeof(SyntaxNode).IsAssignableFrom(property.PropertyType))
                {
                    var child = (SyntaxNode)property.GetValue(this);
                    if (child != null)
                        result.Add(child);
                }
                else if (typeof(IEnumerable<SyntaxNode>).IsAssignableFrom(property.PropertyType))
                {
                    var children = (IEnumerable<SyntaxNode>)property.GetValue(this);
                    foreach (var child in children)
                    {
                        if (child != null)
                            result.Add(child);
                    }
                }
                else if (typeof(BlockNode).IsAssignableFrom(property.PropertyType))
                {
                    var children = (BlockNode)property.GetValue(this);
                    foreach (var child in children.Children)
                    {
                        if (child != null)
                            result.Add(child);
                    }
                }
            }

            return result;
        }

        public Token GetLastToken()
        {
            if (this is Token token)
                return token;

            // A syntax node should always contain at least 1 token.
            return GetChildren().Last().GetLastToken();
        }

        public static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "└──" : "├──";

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write(indent);
            Console.Write(marker);

            Console.ForegroundColor = node is Token ? ConsoleColor.Blue : ConsoleColor.Cyan;

            Console.Write(node.GetType().Name);

            if (node is Token t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }

            Console.ResetColor();

            Console.WriteLine();

            indent += isLast ? "   " : "│  ";

            var lastChild = node.GetChildren().LastOrDefault();

            foreach (var child in node.GetChildren())
                PrettyPrint(child, indent, child == lastChild);
        }
    }
}