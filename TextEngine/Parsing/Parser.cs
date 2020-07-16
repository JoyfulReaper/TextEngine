﻿using System;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using TextEngine.Parsing.Text;

namespace TextEngine.Parsing
{
    public class Parser
    {
        private ImmutableArray<Token> _tokens;
        private int _position;

        public SyntaxNode Parse(string src, string filename = "default.script")
        {
            var lexer = new Lexer(SourceText.From(src, filename));
           
            _tokens = lexer.GetAllTokens().ToImmutableArray();

            return InternalParse();
        }

        private SyntaxNode InternalParse()
        {
            var value = ParseCharacter();
            MatchToken(SyntaxKind.EOF);

            return value;
        }

        private Token Peek(int offset)
        {
            var index = _position + offset;
            if (index >= _tokens.Length)
                return _tokens[^1];

            return _tokens[index];
        }

        public Token MatchUntil(SyntaxKind kind)
        {
            Token token;
            do
            {
                token = MatchToken(kind);
            } while (token.Kind != SyntaxKind.EOF);

            return token;
        }

        public SyntaxNode ParseCharacter()
        {

        }

        private Token Current => Peek(0);

        private Token NextToken()
        {
            var current = Current;
            _position++;
            return current;
        }

        private Token MatchToken(SyntaxKind kind)
        {
            if (Current.Kind == kind)
                return NextToken();

            if (Current.Kind != kind) throw new Exception($"Expected '{kind}' got '{Current.Kind}'");

            return new Token(kind, Current.Position, null, null);
        }
    }
}