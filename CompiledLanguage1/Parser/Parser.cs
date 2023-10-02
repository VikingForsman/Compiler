using System;
using System.Collections.Generic;

using Lexer;

/*  
 *  See the LL(1) language below
 *  
 *  S: T Ss;
 *  Ss: SEMI T Ss | ;
 *  T: ID ASN E | PRINT LPAR L RPAR ;
 *  
 *  L: E Ls;
 *  Ls: COMMA E Ls | ;
 *  
 *  E: F Es;
 *  Es: PLUS F Es | ;
 *  F: ID | NUM | LPAR S COMMA E RPAR ;
*/

namespace Parser {
    public class Parser {
        Lexer.Lexer lexer;

        public Parser(string prg) {
            lexer = new Lexer.Lexer(prg);
        }

        public Parser(Lexer.Lexer lexer) {
            this.lexer = lexer;
        }


        // Helper functions
        public bool IsNext(Token.Type type) {
            return (type == lexer.Peek().type);
        }
        private bool IsNext(Token.Type type, String lexeme) {
            return (type == lexer.Peek().type && lexeme == lexer.Peek().lexeme);
        }
        Token Match() {
            return lexer.Next();
        }
        Token Match(Token.Type type, String lexeme) {
            if (!IsNext(type, lexeme)) {
                // Throw exception due to offending token
                Token o = Match();
                throw new Exception($"Expected {type} {lexeme}. Found ({o.lexeme}) at line {o.line} column {o.column}");
            }
            return lexer.Next();
        }


        // Parse functions
        public Statement Parse() {
            return ParseS();
        }

        private Statement ParseS() {
            var left = ParseT();
            var tree = ParseSs();
            if (tree == null) {
                return left;
            }
            tree.LeftMost().head = left;
            return tree;
        }

        private SequenceStatement ParseSs() {
            if (IsNext(Token.Type.SEP, ";")) {
                Match();
                var right = ParseT();
                var ss = new SequenceStatement(null, right);
                var tree = ParseSs();
                if (tree == null) {
                    return ss;
                }
                tree.LeftMost().head = ss;
                return tree;
            }
            return null;
        }

        private Statement ParseT() {
            // Return assignment statement
            if (IsNext(Token.Type.ID)) {
                var t = Match();
                Match(Token.Type.OP, ":=");
                var e = ParseE();
                return new AssignmentStatement(t.lexeme, e);
            }

            // Return print statement
            if (IsNext(Token.Type.KEYW, "print")) {
                Match();
                Match(Token.Type.SEP, "(");
                var eList = ParseL();
                Match(Token.Type.SEP, ")");
                return new PrintStatement(eList);
            }

            // Throw exception due to offending token
            Token o = Match();
            throw new Exception($"Expected ID or PRINT. Found {o} at line {o.line} column {o.column}");
        }


        private LinkedList<Expression> ParseL() {
            var left = ParseE();
            var tree = ParseLs();
            tree.AddFirst(left);
            return tree;
        }

        private LinkedList<Expression> ParseLs() {
            var eList = new LinkedList<Expression>();
            while (IsNext(Token.Type.SEP, ",")) {
                Match();
                eList.AddLast(ParseE());
            }
            return eList;
        }


        private Expression ParseE() {
            var left = ParseF();
            var tree = ParseEs();
            if (tree == null) {
                return left;
            }
            tree.LeftMost().left = left;
            return tree;
        }

        private BinaryOperatorExpression ParseEs() {
            // Return operator expression
            if (IsNext(Token.Type.OP, "+")) {
                Match();
                var right = ParseF();
                var op = new BinaryOperatorExpression(BinaryOperatorExpression.Type.ADD, null, right);
                var tree = ParseEs();
                if (tree == null) {
                    return op;
                }
                tree.LeftMost().left = op;
                return tree;
            }
            return null;
        }

        private Expression ParseF() {
            // Return number expression
            if (IsNext(Token.Type.NUM)) {
                return new NumberExpression(Match().lexeme);
            }

            // Return identifier expression
            if (IsNext(Token.Type.ID)) {
                return new IdentifierExpression(Match().lexeme);
            }

            // Return let expression
            if (IsNext(Token.Type.SEP, "(")) {
                Match();
                var s = ParseS();
                Match(Token.Type.SEP, ",");
                var e = ParseE();
                Match(Token.Type.SEP, ")");
                return new LetExpression(s, e);
            }

            // Throw exception due to offending token
            Token o = Match();
            throw new Exception($"Expected NUM, ID or LPAR. Found {o} at line {o.line} column {o.column}");
        }
    }
}