﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernate.OData
{
    internal abstract class Token
    {
        protected Token(TokenType type)
        {
            Type = type;
        }

        public TokenType Type { get; private set; }
    }

    internal class NameToken : Token
    {
        public string Name { get; private set; }

        public NameToken(string name)
            : base(TokenType.Name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            Name = name;
        }
    }

    internal class LiteralToken : Token
    {
        public object Value { get; private set; }

        public LiteralToken(object value)
            : base(TokenType.Literal)
        {
            Value = value;
        }
    }

    internal class SyntaxToken : Token
    {
        public static readonly SyntaxToken Minus = new SyntaxToken('-');
        public static readonly SyntaxToken ParenOpen = new SyntaxToken('(');
        public static readonly SyntaxToken ParenClose = new SyntaxToken(')');
        public static readonly SyntaxToken Slash = new SyntaxToken('/');
        public static readonly SyntaxToken Comma = new SyntaxToken(',');

        public char Syntax { get; private set; }

        private SyntaxToken(char syntax)
            : base(TokenType.Syntax)
        {
            Syntax = syntax;
        }
    }
}
