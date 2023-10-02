using System;
using System.Collections.Generic;
using System.Text;

namespace Parser {
    public class Expression {
        public int Line;
        public int column;

        public void SetLocation(QUT.Gppg.LexLocation loc) {
            Line = loc.StartLine;
            column = loc.StartColumn;
        }
    }

    public class LetExpression : Expression {
        public string Name;
        public Expression Expression;
        public Expression Recipient;

        public LetExpression(string name, Expression expression, Expression recipient) {
            Name = name;
            Expression = expression;
            Recipient = recipient;
        }
    }

    public class LetRecExpression : Expression {
        public string Name;
        public string ArgumentName;
        public Expression Body;
        public Expression Recipient;

        public LetRecExpression(string name, string argumentName, Expression body, Expression recipient) {
            Name = name;
            ArgumentName = argumentName;
            Body = body;
            Recipient = recipient;
        }
    }

    public class ApplicationExpression : Expression {
        public string Name;
        public Expression Argument;

        public ApplicationExpression(string name, Expression argument) {
            Name = name;
            Argument = argument;
        }
    }

    public class SequenceExpression : Expression {
        public Expression Expression1;
        public Expression Expression2;

        public SequenceExpression(Expression expression1, Expression expression2) {
            Expression1 = expression1;
            Expression2 = expression2;
        }
    }

    public enum BinaryOperator {Add, Sub, Mul, Div }

    public class BinaryOperatorExpression : Expression {
        public BinaryOperator Operator;
        public Expression Expression1;
        public Expression Expression2;

        public BinaryOperatorExpression(Expression expression1, Expression expression2, BinaryOperator op) {
            Operator = op;
            Expression1 = expression1;
            Expression2 = expression2;
        }
    }

    public class VariableExpression : Expression {
        public string Name;
        public VariableExpression(string name) {
            Name = name;
        }
    }

    public class NumberExpression : Expression {
        public string Value;
        public NumberExpression(string value) {
            Value = value;
        }
    }
}
