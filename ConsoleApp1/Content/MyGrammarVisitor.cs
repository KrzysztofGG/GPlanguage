using System.Globalization;
using Antlr4.Runtime.Tree;
using ConsoleApp1.Content;

namespace ConsoleApp1.Content;

public class MyGrammarVisitor: MyGrammarBaseVisitor<Value>
{
    private Dictionary<string, double> NumVariables { get; } = new();
    private Dictionary<string, bool> BoolVariables { get; } = new();
    private List<string> _output = new();
    private List<Value>? _input = new();
    private int _inputCounter;
    private int operations;
    private int maxOperations;

    public MyGrammarVisitor(List<string> input, int maxOperations)
    { 
        _inputCounter = 0;
        operations = 0;
        _input = input.Select(x => new Value(x)).ToList();
        foreach (var i in input)
        {
            // NumVariables[]
            var varName = "X" + _inputCounter.ToString();
            NumVariables[varName] = _input[_inputCounter % _input.Count].NumValue;
            _inputCounter++;
        }
        this.maxOperations = maxOperations;
    }

    public List<String> visitWithOutput(IParseTree tree)
    {
        try
        {
            Visit(tree);
        }
        catch (Exception e)
        {
            // Console.WriteLine(e.Message);
            return _output;
        }

        return _output;
    }
    public void handleOperations()
    {
        if (maxOperations == -1)
            return;
        operations++;
        if (operations > maxOperations)
        {
            throw new Exception("Too many operations!");
        }
    }

    public override Value VisitIfStatement(MyGrammarParser.IfStatementContext context)
    {
        handleOperations();
        var value =  Visit(context.bool_value());
        if (value.BoolValue)
        {
            return Visit(context.expressions());
        }
        return value;
    }

    public override Value VisitWhileStatement(MyGrammarParser.WhileStatementContext context)
    {
        handleOperations();
        while (Visit(context.bool_value()).BoolValue)
        {
            Visit(context.expressions());
        }

        return new Value(Visit(context.bool_value()).BoolValue);
    }
    public override Value VisitPrintNum(MyGrammarParser.PrintNumContext context)
    {
        handleOperations();
        var value = Visit(context.numeric_value());
        _output.Add(value.NumValue.ToString(CultureInfo.InvariantCulture));
        // Console.Write(value);
        // Console.Write('\n');
        return value;
    }
    public override Value VisitPrintBool(MyGrammarParser.PrintBoolContext context)
    {
        handleOperations();
        var value = Visit(context.bool_value());
        _output.Add(value.BoolValue.ToString());
        // Console.Write(value);
        // Console.Write('\n');
        return value;
    }

    public override Value VisitScanNum(MyGrammarParser.ScanNumContext context)
    {
        handleOperations();
        var varName = context.NUM_VAR().GetText();
        NumVariables[varName] = _input[_inputCounter % _input.Count].NumValue;
        _inputCounter++;
        return new Value(NumVariables[varName]);
    }
    public override Value VisitScanBool(MyGrammarParser.ScanBoolContext context)
    {
        handleOperations();
        var varName = context.BOOL_VAR().GetText();
        BoolVariables[varName] = _input[_inputCounter % _input.Count].BoolValue;
        _inputCounter++;
        return new Value(BoolVariables[varName]);
    }
    public override Value VisitAssignNum(MyGrammarParser.AssignNumContext context)
    {
        handleOperations();
        var varName = context.NUM_VAR().GetText();
        var value = Visit(context.numeric_value());

        NumVariables[varName] = value.NumValue;
        
        return new Value(NumVariables[varName]);
    }

    public override Value VisitAssignBool(MyGrammarParser.AssignBoolContext context)
    {
        handleOperations();
        var varName = context.BOOL_VAR().GetText();
        var value = Visit(context.bool_value());

        BoolVariables[varName] = value.BoolValue;
        
        return new Value(BoolVariables[varName]);
    }

    public override Value VisitBoolVarVal(MyGrammarParser.BoolVarValContext context)
    {
        var varName = context.BOOL_VAR().GetText();

        if (!BoolVariables.ContainsKey(varName))
            // throw new Exception($"Variable {varName} is not defined");
            return new Value(false);
        
        return new Value(BoolVariables[varName]);
    }

    public override Value VisitTrueVal(MyGrammarParser.TrueValContext context)
    {
        return new Value(true);
    }
    public override Value VisitFalseVal(MyGrammarParser.FalseValContext context)
    {
        return new Value(false);
    }
    
    public override Value VisitNotVal(MyGrammarParser.NotValContext context)
    {

        var value = Visit(context.bool_value());
        return Value.Not(value);

        throw new Exception($"{value} not boolean");
    }

    public override Value VisitCompVal(MyGrammarParser.CompValContext context)
    {
        // return 100;
        var left = Visit(context.numeric_value(0));
        var right = Visit(context.numeric_value(1));
        
        if (context.comparisson_type().EQ() != null)
            return Value.Equal(left, right);
        else if (context.comparisson_type().NEQ() != null)
            return Value.NotEqual(left, right);
        else if (context.comparisson_type().LE() != null)
            return Value.Less(left, right);
        else if (context.comparisson_type().LEQ() != null)
            return Value.LessOrEqual(left, right);
        else if (context.comparisson_type().GE() != null)
            return Value.Greater(left, right);
        else if (context.comparisson_type().GEQ() != null)
            return Value.GreaterOrEqual(left, right);
        else
            throw new Exception("Invalid comparison operator");
        
    }

    public override Value VisitLogicVal(MyGrammarParser.LogicValContext context)
    {
        var left = Visit(context.bool_value(0));
        var right = Visit(context.bool_value(1));


        if (context.logic_operator().AND() != null)
            return Value.And(left, right);
        if (context.logic_operator().OR() != null)
            return Value.Or(left, right);
        else
            throw new Exception("Invalid Logic operator");
        
    }

    public override Value VisitParenBoolVal(MyGrammarParser.ParenBoolValContext context)
    {
        return Visit(context.bool_value());
    }
    
    public override Value VisitNumVal(MyGrammarParser.NumValContext context)
    {
        // return double.Parse(context.NUMBER().GetText());
        return new Value(double.Parse(context.NUMBER().GetText()));
    }
    

    public override Value VisitNumVarVal(MyGrammarParser.NumVarValContext context)
    {
        
        var varName = context.NUM_VAR().GetText();

        if (!NumVariables.ContainsKey(varName))
            // throw new Exception($"Variable {varName} is not defined");
            return new Value(0);

        return new Value(NumVariables[varName]);
    }

    public override Value VisitSubVal(MyGrammarParser.SubValContext context)
    {
        var value = Visit(context.numeric_value());
        return new Value(-value.NumValue);
        
    }

    public override Value VisitAritStrongVal(MyGrammarParser.AritStrongValContext context)
    {
        var left = Visit(context.numeric_value(0));
        var right = Visit(context.numeric_value(1));

        var op = context.aritmetic_operator_strong().GetText();
        return op switch
        {
            "*" => Value.Multiply(left, right),
            "/" => Value.Divide(left, right),
            "%" => Value.Modulo(left, right),
            _ => throw new NotImplementedException(),
        };
    }
    
    // private static object? Multiply(object? left, object? right)
    // {
    //     if(left is double ld && right is double rd)
    //         return ld * rd;
    //     if(left is int li && right is int ri)
    //         return li * ri;
    //     
    //     throw new Exception($"Cannot multiply values of types {left.GetType()} and {right.GetType()}");
    // }
    
    // private static object? Divide(object? left, object? right)
    // {
    //     if(left is double ld && right is double rd)
    //         return ld / rd;
    //     if(left is int li && right is int ri)
    //         return li / ri;
    //     throw new Exception($"Cannot divide values of types {left.GetType()} and {right.GetType()}");
    // }
    
    // private static object? Modulo(object? left, object? right)
    // {
    //     if (left is double ld && right is double rd)
    //         throw new Exception("Modulo on double values");
    //     
    //     if(left is int li && right is int ri)
    //         return li % ri;
    //     
    //     throw new Exception($"Cannot modulo values of types {left.GetType()} and {right.GetType()}");
    // }
    
    public override Value VisitAritWeakVal(MyGrammarParser.AritWeakValContext context)
    {
        var left = Visit(context.numeric_value(0));
        var right = Visit(context.numeric_value(1));

        var op = context.aritmetic_operator_weak().GetText();
        return op switch
        {
            "+" => Value.Add(left, right),
            "-" => Value.Subtract(left, right),
            _ => throw new NotImplementedException(),
        };
    }
    
    // private static object? Add(object? left, object? right)
    // {
    //     if(left is double ld && right is double rd)
    //         return ld + rd;
    //     if(left is int li && right is int ri)
    //         return li + ri;
    //     throw new Exception($"Cannot add values of types {left.GetType()} and {right.GetType()}");
    // }
    
    // private static object? Subtract(object? left, object? right)
    // {
    //     return (double)left - (double)right;
    //     
    //     throw new Exception($"Cannot subtract values of types {left.GetType()} and {right.GetType()}");
    // }

    public override Value VisitParenNumVal(MyGrammarParser.ParenNumValContext context)
    {
        return Visit(context.numeric_value());
    }
    
}