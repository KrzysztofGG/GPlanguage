//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\krzys\Desktop\GPlanguage\ConsoleApp1\Content\MyGrammar.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace ConsoleApp1.Content {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="MyGrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IMyGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>aritStrongVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAritStrongVal([NotNull] MyGrammarParser.AritStrongValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>numVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumVal([NotNull] MyGrammarParser.NumValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>numVarVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumVarVal([NotNull] MyGrammarParser.NumVarValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>parenNumVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenNumVal([NotNull] MyGrammarParser.ParenNumValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>subVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubVal([NotNull] MyGrammarParser.SubValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>aritWeakVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAritWeakVal([NotNull] MyGrammarParser.AritWeakValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>whileStatement</c>
	/// labeled alternative in <see cref="MyGrammarParser.while_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatement([NotNull] MyGrammarParser.WhileStatementContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>AssignBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignBool([NotNull] MyGrammarParser.AssignBoolContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>AssignNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignNum([NotNull] MyGrammarParser.AssignNumContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>parenBoolVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenBoolVal([NotNull] MyGrammarParser.ParenBoolValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>compVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompVal([NotNull] MyGrammarParser.CompValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>trueVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTrueVal([NotNull] MyGrammarParser.TrueValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>logicVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicVal([NotNull] MyGrammarParser.LogicValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>notVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotVal([NotNull] MyGrammarParser.NotValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>boolVarVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolVarVal([NotNull] MyGrammarParser.BoolVarValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>falseVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFalseVal([NotNull] MyGrammarParser.FalseValContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>scanBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScanBool([NotNull] MyGrammarParser.ScanBoolContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>scanNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScanNum([NotNull] MyGrammarParser.ScanNumContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>printNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintNum([NotNull] MyGrammarParser.PrintNumContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>printBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintBool([NotNull] MyGrammarParser.PrintBoolContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="MyGrammarParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] MyGrammarParser.IfStatementContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] MyGrammarParser.ProgramContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.expressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressions([NotNull] MyGrammarParser.ExpressionsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf_statement([NotNull] MyGrammarParser.If_statementContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.while_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhile_loop([NotNull] MyGrammarParser.While_loopContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrint_call([NotNull] MyGrammarParser.Print_callContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScan_call([NotNull] MyGrammarParser.Scan_callContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] MyGrammarParser.AssignmentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.comparisson_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparisson_type([NotNull] MyGrammarParser.Comparisson_typeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.logic_operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogic_operator([NotNull] MyGrammarParser.Logic_operatorContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.aritmetic_operator_strong"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAritmetic_operator_strong([NotNull] MyGrammarParser.Aritmetic_operator_strongContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.aritmetic_operator_weak"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAritmetic_operator_weak([NotNull] MyGrammarParser.Aritmetic_operator_weakContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBool_value([NotNull] MyGrammarParser.Bool_valueContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumeric_value([NotNull] MyGrammarParser.Numeric_valueContext context);
}
} // namespace ConsoleApp1.Content