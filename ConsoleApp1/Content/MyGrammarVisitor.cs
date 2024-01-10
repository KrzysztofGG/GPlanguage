using Antlr4.Runtime.Tree;
using ConsoleApp1.Content;

namespace ConsoleApp1.Content;

public class MyGrammarVisitor: MyGrammarBaseVisitor<object?>
{
    private Dictionary<string, object?> NumVariables { get; } = new();
    private Dictionary<string, object?> BoolVariables { get; } = new();
    private List<object?> _output = new();
    private List<string> _input = new();
    private int _inputCounter;
    private int operations;

    public MyGrammarVisitor(List<string> input, int maxOperations)
    { 
        _inputCounter = 0;
        operations = 0;
        _input = input;
    }

    public override object? VisitIfStatement(MyGrammarParser.IfStatementContext context)
    {
        var value =  (bool) Visit(context.bool_value());
        if (value)
        {
            return Visit(context.expressions());
        }
        return value;
    }

    public override object? VisitWhileStatement(MyGrammarParser.WhileStatementContext context)
    {
        while ((bool)Visit(context.bool_value()))
        {
            Visit(context.expressions());
        }

        return Visit(context.bool_value());
    }
    public override object? VisitPrintNum(MyGrammarParser.PrintNumContext context)
    {
        var value = Visit(context.numeric_value());
        _output.Add(value);
        Console.Write(value);
        Console.Write('\n');
        return value;
    }
    public override object? VisitPrintBool(MyGrammarParser.PrintBoolContext context)
    {
        var value = Visit(context.bool_value());
        _output.Add(value);
        Console.Write(value);
        Console.Write('\n');
        return value;
    }

    public override object? VisitScanNum(MyGrammarParser.ScanNumContext context)
    {
        var varName = context.NUM_VAR().GetText();
        NumVariables[varName] = _input[_inputCounter % _input.Count];
        _inputCounter++;
        return NumVariables[varName];
    }
    public override object? VisitScanBool(MyGrammarParser.ScanBoolContext context)
    {
        var varName = context.BOOL_VAR().GetText();
        BoolVariables[varName] = _input[_inputCounter % _input.Count];
        _inputCounter++;
        return BoolVariables[varName];
    }
    public override object? VisitAssignNum(MyGrammarParser.AssignNumContext context)
    {
        var varName = context.NUM_VAR().GetText();
        var value = Visit(context.numeric_value());

        NumVariables[varName] = value;
        
        return null;
    }

    public override object? VisitAssignBool(MyGrammarParser.AssignBoolContext context)
    {
        var varName = context.BOOL_VAR().GetText();
        var value = Visit(context.bool_value());

        BoolVariables[varName] = value;
        
        return null;
    }

    public override object? VisitBoolVarVal(MyGrammarParser.BoolVarValContext context)
    {
        var varName = context.BOOL_VAR().GetText();
        
        if(!BoolVariables.ContainsKey(varName))
            throw new Exception($"Variable {varName} is not defined");

        return BoolVariables[varName];
    }

    public override object? VisitTrueVal(MyGrammarParser.TrueValContext context)
    {
        return true;
    }
    public override object? VisitFalseVal(MyGrammarParser.FalseValContext context)
    {
        return false;
    }
    
    public override object? VisitNotVal(MyGrammarParser.NotValContext context)
    {

        var value = Visit(context.bool_value());
        if (value is bool v)
            return !v;

        throw new Exception($"{value} not boolean");
    }

    public override object? VisitCompVal(MyGrammarParser.CompValContext context)
    {
        var left = Visit(context.numeric_value(0));
        var right = Visit(context.numeric_value(1));

        if (left is double l && right is double r)
        {
            if (context.comparisson_type().EQ() != null)
                return l == r;
            else if (context.comparisson_type().NEQ() != null)
                return l != r;
            else if (context.comparisson_type().LE() != null)
                return l < r;
            else if (context.comparisson_type().LEQ() != null)
                return l <= r;
            else if (context.comparisson_type().GE() != null)
                return l > r;
            else if (context.comparisson_type().GEQ() != null)
                return l >= r;
            else
                throw new Exception("Invalid comparison operator");
        }
        if (left is int li && right is int ri)
        {
            if (context.comparisson_type().EQ() != null)
                return li == ri;
            else if (context.comparisson_type().NEQ() != null)
                return li != li;
            else if (context.comparisson_type().LE() != null)
                return li < ri;
            else if (context.comparisson_type().LEQ() != null)
                return li <= ri;
            else if (context.comparisson_type().GE() != null)
                return li > ri;
            else if (context.comparisson_type().GEQ() != null)
                return li >= ri;
            else
                throw new Exception("Invalid comparison operator");
        }

        return null;
    }

    public override object? VisitLogicVal(MyGrammarParser.LogicValContext context)
    {
        var left = Visit(context.bool_value(0));
        var right = Visit(context.bool_value(1));

        if (left is bool l && right is bool r)
        {
            if (context.logic_operator().AND() != null)
                return l && r;
            
            if (context.logic_operator().OR() != null)
                return l || r;
        }

        return null;

    }

    public override object? VisitParenBoolVal(MyGrammarParser.ParenBoolValContext context)
    {
        return Visit(context.bool_value());
    }
    
    public override object? VisitNumVal(MyGrammarParser.NumValContext context)
    {
        return double.Parse(context.NUMBER().GetText());
    }

    public override object? VisitNumVarVal(MyGrammarParser.NumVarValContext context)
    {
        var varName = context.NUM_VAR().GetText();

        if (!NumVariables.ContainsKey(varName))
            throw new Exception($"Variable {varName} is not defined");
        

        return NumVariables[varName];
    }

    public override object? VisitSubVal(MyGrammarParser.SubValContext context)
    {
        var value = Visit(context.numeric_value());
        if (value is double vd)
            return -vd;
        if (value is int vi)
            return -vi;
        
        throw new Exception($"{value} not a number");
    }

    public override object? VisitAritStrongVal(MyGrammarParser.AritStrongValContext context)
    {
        var left = Visit(context.numeric_value(0));
        var right = Visit(context.numeric_value(1));

        var op = context.aritmetic_operator_strong().GetText();
        return op switch
        {
            "*" => Multiply(left, right),
            "/" => Divide(left, right),
            "%" => Modulo(left, right),
            _ => throw new NotImplementedException(),
        };
    }
    
    private static object? Multiply(object? left, object? right)
    {
        if(left is double ld && right is double rd)
            return ld * rd;
        if(left is int li && right is int ri)
            return li * ri;
        
        throw new Exception($"Cannot multiply values of types {left.GetType()} and {right.GetType()}");
    }
    
    private static object? Divide(object? left, object? right)
    {
        //Throw devide by zero error?
        if(left is double ld && right is double rd)
            return ld / rd;
        if(left is int li && right is int ri)
            return li / ri;
        throw new Exception($"Cannot divide values of types {left.GetType()} and {right.GetType()}");
    }
    
    private static object? Modulo(object? left, object? right)
    {
        if (left is double ld && right is double rd)
            throw new Exception("Modulo on double values");
        
        if(left is int li && right is int ri)
            return li % ri;
        
        throw new Exception($"Cannot modulo values of types {left.GetType()} and {right.GetType()}");
    }
    
    public override object? VisitAritWeakVal(MyGrammarParser.AritWeakValContext context)
    {
        var left = Visit(context.numeric_value(0));
        var right = Visit(context.numeric_value(1));

        var op = context.aritmetic_operator_weak().GetText();
        return op switch
        {
            "+" => Add(left, right),
            "-" => Subtract(left, right),
            _ => throw new NotImplementedException(),
        };
    }
    
    private static object? Add(object? left, object? right)
    {
        if(left is double ld && right is double rd)
            return ld + rd;
        if(left is int li && right is int ri)
            return li + ri;
        throw new Exception($"Cannot add values of types {left.GetType()} and {right.GetType()}");
    }
    
    private static object? Subtract(object? left, object? right)
    {
        if(left is double ld && right is double rd)
            return ld - rd;
        if(left is int li && right is int ri)
            return li - ri;
        throw new Exception($"Cannot subtract values of types {left.GetType()} and {right.GetType()}");
    }

    public override object? VisitParenNumVal(MyGrammarParser.ParenNumValContext context)
    {
        return Visit(context.numeric_value());
    }
    
    
    //
    // public override object? VisitNumeric_value(MyGrammarParser.Numeric_valueContext context)
    // {
    //     if (context.NUMBER() != null)
    //         return float.Parse(context.NUMBER().GetText());
    //
    //     if (context.NUM_VAR() is { } n)
    //     {
    //         if (!Variables.ContainsKey(n.GetText()))
    //             throw new Exception("Reading undefined variable");
    //         
    //         return Variables[n.GetText()];
    //     }
    //
    //     if (context.SUB() != null && context.numeric_value().Length == 1) // Not sure
    //         return -float.Parse(context.GetText());
    //
    //         
    //     return null;
    //     
    // }

    // public override object? VisitAritmetic_operator_strong(MyGrammarParser.Aritmetic_operator_strongContext context)
    // {
    //     var left = Visit(context.)
    // }
    
}