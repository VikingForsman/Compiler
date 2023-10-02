using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Lexer {
    public class Lexer {
        private List<Token> tokens = new List<Token>();
        private int iterator = 0, line = 1, column = 1;

        public Lexer(string text) {
            char[] newlines = { '\n', '\r' };
            char[] separators = { '(', ')', ';', ',' };
            char[] operators = { '+', ':' };
            string[] keywords = { "print" };

            while (iterator < text.Length) {
                char c = text[iterator];
                string lexeme = "";

                // Only one type of whitespace. 
                if (c == ' ') {
                    iterator++;
                    column++;
                }

                // Three types of newlines, on of which has two chars.
                else if (newlines.Contains(c)) {
                    if (iterator + 1 < text.Length && c == '\r' && text[iterator + 1] == '\n') {
                        iterator += 2;
                        line++;
                        column = 1;
                    } else {
                        iterator++;
                        line++;
                        column = 1;
                    }
                }

                // If c is a digit it must be a number. 
                else if (char.IsDigit(c)) {
                    lexeme = "";
                    while (iterator < text.Length && char.IsDigit(text[iterator])) {
                        lexeme += text[iterator];
                        iterator++;
                    }
                    AddToken(Token.Type.NUM, lexeme, line, column);
                    column += lexeme.Length;
                }

                // If c is a letter it can be a keyword or id.
                else if (char.IsLetter(c)) {
                    lexeme = "";
                    while (iterator < text.Length && char.IsLetterOrDigit(text[iterator])) {
                        lexeme += text[iterator];
                        iterator++;
                    }
                    if (keywords.Contains(lexeme)) {
                        AddToken(Token.Type.KEYW, lexeme, line, column);
                    } else {
                        AddToken(Token.Type.ID, lexeme, line, column);
                    }
                    column += lexeme.Length;
                }

                // If c is one of the separator characters it must be a separator.
                else if (separators.Contains(c)) {
                    AddToken(Token.Type.SEP, c.ToString(), line, column);
                    column++;
                    iterator++;
                }

                // If c is one of the operator characters it must be a operator.
                else if (operators.Contains(c)) {
                    if (iterator + 1 < text.Length && c == ':' && text[iterator + 1] == '=') {
                        AddToken(Token.Type.OP, ":=", line, column);
                        iterator += 2;
                        column += 2;
                    } else if (c == '+') {
                        AddToken(Token.Type.OP, "+", line, column);
                        iterator++;
                        column++;
                    } else {
                        throw new NotImplementedException();
                    }
                }

                // Wo alle Straßen enden! Were not supposed to be here, but just in case.
                else {
                    Console.WriteLine(c);
                    throw new NotImplementedException();
                }
            }

            // Add EOF token and reset iterator
            AddToken(Token.Type.EOF, string.Empty, line, column);
            iterator = 0;
        }

        public Token Next() {
            return tokens[iterator++];
        }


        public Token Peek() {
            //if (tokens.Count() > iterator)
            //    return tokens[iterator];
            return tokens[iterator];
        }

        private void AddToken(Token.Type token, string lexeme, int line, int column) {
            tokens.Add(new Token(token, lexeme, line, column));
        }
    }
}
