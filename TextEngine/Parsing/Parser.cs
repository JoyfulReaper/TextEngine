using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text.RegularExpressions;
using TextEngine.Parsing.Syntax;
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
            var value = ParseBlock();
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
            } while (token.Kind != SyntaxKind.EOF && token.Kind == kind);

            return token;
        }

        public bool MatchCurrentKeyword(string keyword)
        {
            return Current.Kind == SyntaxKind.Keyword && Current.Text == keyword;
        }

        public SyntaxNode ParseBlock()
        {
            var members = ParseMembers();

            return new BlockNode(members);
        }

        private IEnumerable<SyntaxNode> ParseMembers()
        {
            var members = new List<SyntaxNode>();

            while (Current.Kind != SyntaxKind.EOF)
            {
                var startToken = Current;
                var member = ParseMember();

                if (member is BlockNode bn)
                {
                    members.AddRange(bn.Children);
                }
                else
                {
                    members.Add(member);
                }

                // If ParseMember() did not consume any tokens,
                // we need to skip the current token and continue
                // in order to avoid an infinite loop.
                //
                // We don't need to report an error, because we'll
                // already tried to parse an expression statement
                // and reported one.
                if (Current == startToken)
                    NextToken();
            }

            return members;
        }

        private SyntaxNode ParseMember()
        {
            if(MatchCurrentKeyword("character"))
            {
                return ParsePropertyOnly<CharacterDefinitionNode>("character");
            }
            else if (MatchCurrentKeyword("weapon"))
            {
                return ParsePropertyOnly<WeaponDefinitionNode>("weapon");
            }
            else if (MatchCurrentKeyword("key"))
            {
                return ParsePropertyOnly<KeyDefinitionNode>("key");
            }
            else if (MatchCurrentKeyword("include"))
            {
                return ParseInclude();
            }
            else if (MatchCurrentKeyword("tell"))
            {
                return ParseTell();
            }
            else if(MatchCurrentKeyword("memory"))
            {
                return ParseMemorySlot();
            }
            else if(MatchCurrentKeyword("on"))
            {
                return ParseEventSubscription();
            }

            return null;
        }

        private SyntaxNode ParseEventSubscription()
        {
            var keyword = MatchKeyword("on");
            var name = MatchToken(SyntaxKind.String);
            var body = (BlockNode)ParseProcedureBlock();

            return new EventSubscriptionNode(name.Value.ToString(), body);
        }

        private BlockNode ParseProcedureBlock()
        {
            var members = new List<SyntaxNode>();

            while(Current.Kind != SyntaxKind.EndToken)
            {
                members.Add(ParseMember());
            }

            MatchToken(SyntaxKind.EndToken);

            return new BlockNode(members);
        }

        private SyntaxNode ParseMemorySlot()
        {
            var keyword = MatchKeyword("memory");
            var slotname = MatchToken(SyntaxKind.String);
            object initialvalue = null;
            if (MatchCurrentKeyword("equals"))
            {
                var equalsToken = MatchKeyword("equals");
                initialvalue = MatchToken(SyntaxKind.String).Value; // replace with ParseValue()
            }

            return new MemorySlotDefinition(slotname.Value.ToString(), initialvalue);
        }

        private SyntaxNode ParseTell()
        {
            MatchKeyword("tell");
            var message = MatchToken(SyntaxKind.String);

            return new TellNode(message.Value.ToString());
        }

        private SyntaxNode ParseInclude()
        {
            MatchKeyword("include");
            var filename = MatchToken(SyntaxKind.String);

            var p = new Parser();
            var tree = p.Parse(File.ReadAllText(filename.Value.ToString()));

            return tree;
        }

        private T ParsePropertyOnly<T>(string keyword)
            where T : PropertyOnlyBasedCommand
        {
            MatchKeyword(keyword);
            var name = MatchToken(SyntaxKind.String);
            MatchKeyword("with");
            var properties = ParsePropertyList();

            var result = (T)Activator.CreateInstance(typeof(T), name.Text, properties);
            MatchToken(SyntaxKind.EndToken);

            return result;
        }

        private Dictionary<string, object> ParsePropertyList()
        {
            var result = new Dictionary<string, object>();

            var parseNextArgument = true;
            while (parseNextArgument &&
                   Current.Kind != SyntaxKind.EndToken &&
                   Current.Kind != SyntaxKind.EOF)
            {
                var prop = ParseProperty();
                result.Add(prop.name, prop.value);

                if(!AcceptKeyword("and", out var andToken))
                {
                    parseNextArgument = false;
                }
            }


            return result;
        }



        public bool AcceptKeyword(string keyword, out Token token)
        {
            try
            {
                token = MatchKeyword(keyword);
                return true;
            }
            catch
            {
                token = new Token(SyntaxKind.BadToken, -1, null, null);
                return false;
            }
        }

        private (string name, SyntaxNode value) ParseProperty()
        {
            var name = MatchToken(SyntaxKind.Keyword);
            var value = MatchToken(SyntaxKind.Number);

            return (name.Text, new LiteralNode(int.Parse(value.Text)));
        }

        public Token MatchKeyword(string keyword)
        {
            var keywordToken = MatchToken(SyntaxKind.Keyword);
            if(keywordToken.Text == keyword)
            {
                return keywordToken;
            }

            throw new Exception($"expected '{keyword}' got '{keywordToken.Text}'");
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