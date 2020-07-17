using System;
using System.Collections.Generic;
using System.Text;
using TextEngine.Parsing.Text;

namespace TextEngine.Parsing
{
    /// <summary>
    ///  A Tokenizer
    /// </summary>
    public sealed class Lexer
    {
        private readonly SourceText _text;
        private int _position;

        private int _start;
        private SyntaxKind _kind;
        private object _value;

        public Lexer(SourceText src)
        {
            _text = src;
        }

        public IEnumerable<Token> GetAllTokens()
        {
            Token token;
            do
            {
                token = Lex();

                if (token.Kind != SyntaxKind.Whitespace &&
                    token.Kind != SyntaxKind.BadToken)
                {
                    yield return token;
                }
            } while (token.Kind != SyntaxKind.EOF);
        }

        private char Current => Peek(0);

        private char Lookahead => Peek(1);

        private char Peek(int offset)
        {
            var index = _position + offset;

            if (index >= _text.Length)
                return '\0';

            return _text[index];
        }

        public Token Lex()
        {
            _start = _position;
            _kind = SyntaxKind.BadToken;
            _value = null;

            switch (Current)
            {
                case '\0':
                    _kind = SyntaxKind.EOF;
                    break;
                case '"':
                    ReadDoubleQuotedString();
                    break;
                case '\'':
                    ReadSingleQuotedString();
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    ReadNumberToken();
                    break;
                case ' ':
                case '\t':
                case '\n':
                case '\r':
                    ReadWhiteSpace();
                    break;
                default:
                    if (char.IsLetter(Current))
                    {
                        ReadKeyword();
                    }
                    else if (char.IsWhiteSpace(Current))
                    {
                        ReadWhiteSpace();
                    }

                    break;
            }

            var length = _position - _start;
            var text = _text.ToString(_start, length);

            return new Token(_kind, _start, text, _value);
        }

        private void ReadKeyword()
        {
            while (char.IsLetter(Current))
                _position++;

            var length = _position - _start;
            var text = _text.ToString(_start, length);

            if(text == "end")
            {
                _kind = SyntaxKind.EndToken;
                return;
            }

            _kind = SyntaxKind.Keyword;
        }

        private void ReadSingleQuotedString()
        {
            // Skip the current quote
            _position++;

            var sb = new StringBuilder();
            var done = false;

            while (!done)
            {
                switch (Current)
                {
                    case '\0':
                    case '\r':
                    case '\n':
                        done = true;
                        break;
                    case '"':
                        if (Lookahead == '\'')
                        {
                            sb.Append(Current);
                            _position += 2;
                        }
                        else
                        {
                            _position++;
                            done = true;
                        }
                        break;
                    default:
                        sb.Append(Current);
                        _position++;
                        break;
                }
            }

            _kind = SyntaxKind.String;
            _value = sb.ToString();
        }

        private void ReadDoubleQuotedString()
        {
            // Skip the current quote
            _position++;

            var sb = new StringBuilder();
            var done = false;

            while (!done)
            {
                switch (Current)
                {
                    case '\0':
                    case '\r':
                    case '\n':
                        done = true;
                        break;
                    case '"':
                        if (Lookahead == '"')
                        {
                            sb.Append(Current);
                            _position += 2;
                        }
                        else
                        {
                            _position++;
                            done = true;
                        }
                        break;
                    default:
                        sb.Append(Current);
                        _position++;
                        break;
                }
            }

            _kind = SyntaxKind.String;
            _value = sb.ToString();
        }

        private void ReadWhiteSpace()
        {
            while (char.IsWhiteSpace(Current))
                _position++;

            _kind = SyntaxKind.Whitespace;
        }

        private void ReadNumberToken()
        {
            while (char.IsDigit(Current))
                _position++;

            var length = _position - _start;
            var text = _text.ToString(_start, length);
            if (!int.TryParse(text, out var value))
            {
                
            }

            _value = value;
            _kind = SyntaxKind.Number;
        }
    }
}