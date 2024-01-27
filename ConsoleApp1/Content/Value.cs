namespace ConsoleApp1.Content;

public class Value
{
    public double NumValue { get; set; }
    public bool BoolValue { get; set; }

    public Value()
    {
        this.NumValue = 0;
        this.BoolValue = false;
    }

    public Value(double numValue)
    {
        this.NumValue = numValue;
        this.BoolValue = numValue != 0;
    }

    public Value(bool boolValue)
    {
        this.BoolValue = boolValue;
        this.NumValue = boolValue ? 1 : 0;
    }

    public Value(string val)
    {
        if (val == "true")
        {
            this.BoolValue = true;
            this.NumValue = 1;
        }
        else if (val == "false")
        {
            this.BoolValue = false;
            this.NumValue = 0;
        }
        else
        {
            this.BoolValue = false;
            this.NumValue = double.Parse(val);
        }

    }

    public static Value Not(Value val)
    {
        return new Value(!val.BoolValue);
    }
    
    public static Value Equal(Value val1, Value val2)
    {
        if (Math.Abs(val1.NumValue - val2.NumValue) < 0.00001)
            return new Value(true);
        else
            return new Value(false);
    }
    
    public static Value NotEqual(Value val1, Value val2)
    { 
        if (Math.Abs(val1.NumValue - val2.NumValue) > 0.00001)
            return new Value(true);
        else
            return new Value(false);
    }
    
    public static Value Less(Value val1, Value val2)
    { 
        return new Value(val1.NumValue < val2.NumValue);
    }
    
    public static Value LessOrEqual(Value val1, Value val2)
    { 
        return new Value(val1.NumValue <= val2.NumValue);
    }
    
    public static Value Greater(Value val1, Value val2)
    { 
        return new Value(val1.NumValue > val2.NumValue);
    }
    
    public static Value GreaterOrEqual(Value val1, Value val2)
    { 
        return new Value(val1.NumValue >= val2.NumValue);
    }

    public static Value And(Value val1, Value val2)
    {
        return new Value(val1.BoolValue && val2.BoolValue);
    }    
    public static Value Or(Value val1, Value val2)
    {
        return new Value(val1.BoolValue || val2.BoolValue);
    }

    public static Value Multiply(Value val1, Value val2)
    {
        return new Value(val1.NumValue * val2.NumValue);
    }
    public static Value Divide(Value val1, Value val2)
    {
        if (Math.Abs(val2.NumValue) < 0.00001)
            return new Value(val1.NumValue);
        return new Value(val1.NumValue / val2.NumValue);
    }
    public static Value Modulo(Value val1, Value val2)
    {
        if (Math.Abs(val2.NumValue) < 0.00001)
            return new Value(val1.NumValue);
        return new Value(val1.NumValue % val2.NumValue);
    }
    
    public static Value Add(Value val1, Value val2)
    { 
        return new Value(val1.NumValue + val2.NumValue);
    }
    
    public static Value Subtract(Value val1, Value val2)
    { 
        return new Value(val1.NumValue - val2.NumValue);
    }
    
}