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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="MyGrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IMyGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>aritStrongVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAritStrongVal([NotNull] MyGrammarParser.AritStrongValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>aritStrongVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAritStrongVal([NotNull] MyGrammarParser.AritStrongValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>numVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumVal([NotNull] MyGrammarParser.NumValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>numVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumVal([NotNull] MyGrammarParser.NumValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>numVarVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumVarVal([NotNull] MyGrammarParser.NumVarValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>numVarVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumVarVal([NotNull] MyGrammarParser.NumVarValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parenNumVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenNumVal([NotNull] MyGrammarParser.ParenNumValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parenNumVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenNumVal([NotNull] MyGrammarParser.ParenNumValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>subVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubVal([NotNull] MyGrammarParser.SubValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>subVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubVal([NotNull] MyGrammarParser.SubValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>aritWeakVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAritWeakVal([NotNull] MyGrammarParser.AritWeakValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>aritWeakVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAritWeakVal([NotNull] MyGrammarParser.AritWeakValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>whileStatement</c>
	/// labeled alternative in <see cref="MyGrammarParser.while_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileStatement([NotNull] MyGrammarParser.WhileStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>whileStatement</c>
	/// labeled alternative in <see cref="MyGrammarParser.while_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileStatement([NotNull] MyGrammarParser.WhileStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>AssignBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignBool([NotNull] MyGrammarParser.AssignBoolContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>AssignBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignBool([NotNull] MyGrammarParser.AssignBoolContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>AssignNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignNum([NotNull] MyGrammarParser.AssignNumContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>AssignNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignNum([NotNull] MyGrammarParser.AssignNumContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parenBoolVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenBoolVal([NotNull] MyGrammarParser.ParenBoolValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parenBoolVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenBoolVal([NotNull] MyGrammarParser.ParenBoolValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>compVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompVal([NotNull] MyGrammarParser.CompValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>compVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompVal([NotNull] MyGrammarParser.CompValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>trueVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTrueVal([NotNull] MyGrammarParser.TrueValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>trueVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTrueVal([NotNull] MyGrammarParser.TrueValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>logicVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicVal([NotNull] MyGrammarParser.LogicValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>logicVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicVal([NotNull] MyGrammarParser.LogicValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>notVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNotVal([NotNull] MyGrammarParser.NotValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>notVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNotVal([NotNull] MyGrammarParser.NotValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>boolVarVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolVarVal([NotNull] MyGrammarParser.BoolVarValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>boolVarVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolVarVal([NotNull] MyGrammarParser.BoolVarValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>falseVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFalseVal([NotNull] MyGrammarParser.FalseValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>falseVal</c>
	/// labeled alternative in <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFalseVal([NotNull] MyGrammarParser.FalseValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>scanBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScanBool([NotNull] MyGrammarParser.ScanBoolContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>scanBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScanBool([NotNull] MyGrammarParser.ScanBoolContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>scanNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScanNum([NotNull] MyGrammarParser.ScanNumContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>scanNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScanNum([NotNull] MyGrammarParser.ScanNumContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>printNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintNum([NotNull] MyGrammarParser.PrintNumContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>printNum</c>
	/// labeled alternative in <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintNum([NotNull] MyGrammarParser.PrintNumContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>printBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintBool([NotNull] MyGrammarParser.PrintBoolContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>printBool</c>
	/// labeled alternative in <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintBool([NotNull] MyGrammarParser.PrintBoolContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="MyGrammarParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] MyGrammarParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="MyGrammarParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] MyGrammarParser.IfStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] MyGrammarParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] MyGrammarParser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.expressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressions([NotNull] MyGrammarParser.ExpressionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.expressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressions([NotNull] MyGrammarParser.ExpressionsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIf_statement([NotNull] MyGrammarParser.If_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIf_statement([NotNull] MyGrammarParser.If_statementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.while_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhile_loop([NotNull] MyGrammarParser.While_loopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.while_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhile_loop([NotNull] MyGrammarParser.While_loopContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrint_call([NotNull] MyGrammarParser.Print_callContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.print_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrint_call([NotNull] MyGrammarParser.Print_callContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScan_call([NotNull] MyGrammarParser.Scan_callContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.scan_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScan_call([NotNull] MyGrammarParser.Scan_callContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] MyGrammarParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] MyGrammarParser.AssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.comparisson_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisson_type([NotNull] MyGrammarParser.Comparisson_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.comparisson_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisson_type([NotNull] MyGrammarParser.Comparisson_typeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.logic_operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogic_operator([NotNull] MyGrammarParser.Logic_operatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.logic_operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogic_operator([NotNull] MyGrammarParser.Logic_operatorContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.aritmetic_operator_strong"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAritmetic_operator_strong([NotNull] MyGrammarParser.Aritmetic_operator_strongContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.aritmetic_operator_strong"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAritmetic_operator_strong([NotNull] MyGrammarParser.Aritmetic_operator_strongContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.aritmetic_operator_weak"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAritmetic_operator_weak([NotNull] MyGrammarParser.Aritmetic_operator_weakContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.aritmetic_operator_weak"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAritmetic_operator_weak([NotNull] MyGrammarParser.Aritmetic_operator_weakContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBool_value([NotNull] MyGrammarParser.Bool_valueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.bool_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBool_value([NotNull] MyGrammarParser.Bool_valueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumeric_value([NotNull] MyGrammarParser.Numeric_valueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MyGrammarParser.numeric_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumeric_value([NotNull] MyGrammarParser.Numeric_valueContext context);
}
} // namespace ConsoleApp1.Content
