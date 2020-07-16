using TextEngine.Parsing.Text;

namespace TextEngine.Parsing
{
    /// <summary>
    ///  A class to represent a Token
    /// </summary>
    public sealed class Token : SyntaxNode
    {
        /// <summary>
        ///  initialize Token
        /// </summary>
        /// <param name="kind">The TokenTýpe</param>
        /// <param name="position">The startposition of the Token</param>
        /// <param name="text">The resulting Text</param>
        /// <param name="value">The Value. Can be Null</param>
        public Token(SyntaxKind kind, int position, string text, object value)
        {
            Kind = kind;
            Position = position;
            Text = text;
            Value = value;
        }


        /// <summary>
        ///  The TokenType
        /// </summary>
        public SyntaxKind Kind { get; }

        /// <summary>
        ///  The Startposition
        /// </summary>
        public int Position { get; }

        /// <summary>
        ///  The Token Text
        /// </summary>
        public string Text { get; }

        /// <summary>
        ///  The Token Value
        /// </summary>
        public object Value { get; }

        /// <summary>
        ///  The TokenSpan
        /// </summary>
        public override TextSpan Span => new TextSpan(Position, Text?.Length ?? 0);

        public override string ToString() => Kind + ": " + Text;
    }
}