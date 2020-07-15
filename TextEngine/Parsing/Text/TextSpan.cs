namespace TextEngine.Parsing.Text
{
    /// <summary>
    ///  A Class that represents a span of a source text
    /// </summary>
    public struct TextSpan
    {
        /// <summary>
        ///  initialize the span
        /// </summary>
        /// <param name="start">start position</param>
        /// <param name="length">length of the span</param>
        public TextSpan(int start, int length)
        {
            Start = start;
            Length = length;
        }

        /// <summary>
        ///  The Start of the Span
        /// </summary>
        public int Start { get; }

        /// <summary>
        ///  The Length of the Span
        /// </summary>
        public int Length { get; }

        /// <summary>
        ///  The End of The Span
        /// </summary>
        public int End => Start + Length;

        /// <summary>
        ///  Generate a Span
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static TextSpan FromBounds(int start, int end)
        {
            var length = end - start;
            return new TextSpan(start, length);
        }

        /// <summary>
        ///  Convert Span to string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Start}..{End}";
    }
}