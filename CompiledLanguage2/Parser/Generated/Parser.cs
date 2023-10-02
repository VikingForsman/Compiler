// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  DESKTOP-IIF7GAE
// DateTime: 2020-11-27 22:13:57
// UserName: Viking
// Input file <.\Parser.y - 2020-11-27 22:13:40>

// options: lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace Parser
{
public enum Tokens {error=2,EOF=3,ID=4,NUM=5,LEXERR=6,
    COMMA=7,ASN=8,LPAR=9,RPAR=10,ADD=11,SUB=12,
    MUL=13,DIV=14,LET=15,IN=16};

public struct ValueType
#line 5 ".\Parser.y"
       {
  public string Value;
  public Expression Expression;
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[19];
  private static State[] states = new State[38];
  private static string[] nonTerms = new string[] {
      "E", "E1", "E2", "E3", "E4", "E5", "P", "$accept", };

  static Parser() {
    states[0] = new State(new int[]{15,7,4,18,9,20,5,28},new int[]{-7,1,-1,3,-2,23,-3,13,-4,24,-5,29,-6,27});
    states[1] = new State(new int[]{3,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{3,4,7,5});
    states[4] = new State(-2);
    states[5] = new State(new int[]{15,7,4,18,9,20,5,28},new int[]{-2,6,-3,13,-4,24,-5,29,-6,27});
    states[6] = new State(-3);
    states[7] = new State(new int[]{4,8});
    states[8] = new State(new int[]{8,9,4,33});
    states[9] = new State(new int[]{15,7,4,18,9,20,5,28},new int[]{-1,10,-2,23,-3,13,-4,24,-5,29,-6,27});
    states[10] = new State(new int[]{16,11,7,5});
    states[11] = new State(new int[]{15,7,4,18,9,20,5,28},new int[]{-2,12,-3,13,-4,24,-5,29,-6,27});
    states[12] = new State(-5);
    states[13] = new State(new int[]{11,14,12,31,3,-7,7,-7,16,-7,10,-7});
    states[14] = new State(new int[]{4,18,9,20,5,28},new int[]{-4,15,-5,29,-6,27});
    states[15] = new State(new int[]{13,16,14,25,11,-8,12,-8,3,-8,7,-8,16,-8,10,-8});
    states[16] = new State(new int[]{4,18,9,20,5,28},new int[]{-5,17,-6,27});
    states[17] = new State(-11);
    states[18] = new State(new int[]{9,20,4,30,5,28,13,-17,14,-17,11,-17,12,-17,3,-17,7,-17,16,-17,10,-17},new int[]{-6,19});
    states[19] = new State(-14);
    states[20] = new State(new int[]{15,7,4,18,9,20,5,28},new int[]{-1,21,-2,23,-3,13,-4,24,-5,29,-6,27});
    states[21] = new State(new int[]{10,22,7,5});
    states[22] = new State(-16);
    states[23] = new State(-4);
    states[24] = new State(new int[]{13,16,14,25,11,-10,12,-10,3,-10,7,-10,16,-10,10,-10});
    states[25] = new State(new int[]{4,18,9,20,5,28},new int[]{-5,26,-6,27});
    states[26] = new State(-12);
    states[27] = new State(-15);
    states[28] = new State(-18);
    states[29] = new State(-13);
    states[30] = new State(-17);
    states[31] = new State(new int[]{4,18,9,20,5,28},new int[]{-4,32,-5,29,-6,27});
    states[32] = new State(new int[]{13,16,14,25,11,-9,12,-9,3,-9,7,-9,16,-9,10,-9});
    states[33] = new State(new int[]{8,34});
    states[34] = new State(new int[]{15,7,4,18,9,20,5,28},new int[]{-1,35,-2,23,-3,13,-4,24,-5,29,-6,27});
    states[35] = new State(new int[]{16,36,7,5});
    states[36] = new State(new int[]{15,7,4,18,9,20,5,28},new int[]{-2,37,-3,13,-4,24,-5,29,-6,27});
    states[37] = new State(-6);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-8, new int[]{-7,3});
    rules[2] = new Rule(-7, new int[]{-1,3});
    rules[3] = new Rule(-1, new int[]{-1,7,-2});
    rules[4] = new Rule(-1, new int[]{-2});
    rules[5] = new Rule(-2, new int[]{15,4,8,-1,16,-2});
    rules[6] = new Rule(-2, new int[]{15,4,4,8,-1,16,-2});
    rules[7] = new Rule(-2, new int[]{-3});
    rules[8] = new Rule(-3, new int[]{-3,11,-4});
    rules[9] = new Rule(-3, new int[]{-3,12,-4});
    rules[10] = new Rule(-3, new int[]{-4});
    rules[11] = new Rule(-4, new int[]{-4,13,-5});
    rules[12] = new Rule(-4, new int[]{-4,14,-5});
    rules[13] = new Rule(-4, new int[]{-5});
    rules[14] = new Rule(-5, new int[]{4,-6});
    rules[15] = new Rule(-5, new int[]{-6});
    rules[16] = new Rule(-6, new int[]{9,-1,10});
    rules[17] = new Rule(-6, new int[]{4});
    rules[18] = new Rule(-6, new int[]{5});

    aliases = new Dictionary<int, string>();
    aliases.Add(7, ",");
    aliases.Add(8, "=");
    aliases.Add(9, "(");
    aliases.Add(10, ")");
    aliases.Add(11, "+");
    aliases.Add(12, "-");
    aliases.Add(13, "*");
    aliases.Add(14, "/");
    aliases.Add(15, "let");
    aliases.Add(16, "in");
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // P -> E, EOF
#line 33 ".\Parser.y"
                { result = ValueStack[ValueStack.Depth-2].Expression; }
#line default
        break;
      case 3: // E -> E, ",", E1
#line 37 ".\Parser.y"
                  { CurrentSemanticValue.Expression = new SequenceExpression(ValueStack[ValueStack.Depth-3].Expression, ValueStack[ValueStack.Depth-1].Expression); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 4: // E -> E1
#line 38 ".\Parser.y"
               { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression; }
#line default
        break;
      case 5: // E1 -> "let", ID, "=", E, "in", E1
#line 41 ".\Parser.y"
                             { CurrentSemanticValue.Expression = new LetExpression(ValueStack[ValueStack.Depth-5].Value, ValueStack[ValueStack.Depth-3].Expression, ValueStack[ValueStack.Depth-1].Expression); }
#line default
        break;
      case 6: // E1 -> "let", ID, ID, "=", E, "in", E1
#line 42 ".\Parser.y"
                               { CurrentSemanticValue.Expression = new LetRecExpression(ValueStack[ValueStack.Depth-6].Value, ValueStack[ValueStack.Depth-5].Value, ValueStack[ValueStack.Depth-3].Expression, ValueStack[ValueStack.Depth-1].Expression); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 7: // E1 -> E2
#line 43 ".\Parser.y"
              { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression; }
#line default
        break;
      case 8: // E2 -> E2, "+", E3
#line 46 ".\Parser.y"
                    { CurrentSemanticValue.Expression = new BinaryOperatorExpression(ValueStack[ValueStack.Depth-3].Expression, ValueStack[ValueStack.Depth-1].Expression, BinaryOperator.Add); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 9: // E2 -> E2, "-", E3
#line 47 ".\Parser.y"
                    { CurrentSemanticValue.Expression = new BinaryOperatorExpression(ValueStack[ValueStack.Depth-3].Expression, ValueStack[ValueStack.Depth-1].Expression, BinaryOperator.Sub); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 10: // E2 -> E3
#line 48 ".\Parser.y"
               { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression; }
#line default
        break;
      case 11: // E3 -> E3, "*", E4
#line 51 ".\Parser.y"
                    { CurrentSemanticValue.Expression = new BinaryOperatorExpression(ValueStack[ValueStack.Depth-3].Expression, ValueStack[ValueStack.Depth-1].Expression, BinaryOperator.Mul); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 12: // E3 -> E3, "/", E4
#line 52 ".\Parser.y"
                    { CurrentSemanticValue.Expression = new BinaryOperatorExpression(ValueStack[ValueStack.Depth-3].Expression, ValueStack[ValueStack.Depth-1].Expression, BinaryOperator.Div); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 13: // E3 -> E4
#line 53 ".\Parser.y"
               { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression; }
#line default
        break;
      case 14: // E4 -> ID, E5
#line 56 ".\Parser.y"
                 { CurrentSemanticValue.Expression = new ApplicationExpression(ValueStack[ValueStack.Depth-2].Value, ValueStack[ValueStack.Depth-1].Expression); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 15: // E4 -> E5
#line 57 ".\Parser.y"
               { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression; }
#line default
        break;
      case 16: // E5 -> "(", E, ")"
#line 60 ".\Parser.y"
                    { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-2].Expression; }
#line default
        break;
      case 17: // E5 -> ID
#line 61 ".\Parser.y"
               { CurrentSemanticValue.Expression = new VariableExpression(ValueStack[ValueStack.Depth-1].Value); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 18: // E5 -> NUM
#line 62 ".\Parser.y"
               { CurrentSemanticValue.Expression = new NumberExpression(ValueStack[ValueStack.Depth-1].Value); CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 66 ".\Parser.y"

public Expression result;
public Parser(Scanner s) : base(s) { }
#line default
}
}
