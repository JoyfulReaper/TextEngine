namespace TextEngine.Parsing
{
    /// <summary>
    ///  Represent the TokenType
    /// </summary>
    public enum SyntaxKind
    {
        /// <summary>
        ///  EndOfFile Token
        /// </summary>
        EOF,

        /// <summary>
        ///  Identifier Token
        /// </summary>
        Identifier,

        /// <summary>
        ///  String Token
        /// </summary>
        String,

        /// <summary>
        ///  Number Token
        /// </summary>
        Number,
    }
}