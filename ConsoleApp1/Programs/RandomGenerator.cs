public class RandomGenerator{
    static Random random = new Random();

    public static int generateRandomInt(int lowerBound, int upperBound){
        return random.Next(lowerBound, upperBound+1);
    }

    // public static Node getRandomProgramNode(Program program)
    // {
    //     return program.nodes[];
    // }
    
public static Node generateRandomNode(int depth){
    int val = random.Next(1,5);
    if(depth<=1){
        val = random.Next(1,3);
    }

    // if(val==0){
    //     return new InputNode();
    // }
    if(val==1){
        return new AssignmentNode();
    }
    if(val==2){
        return new OutputNode();
    }
    if(val==3){
        return new WhileNode(depth);
    }
    return new IfNode(depth);
}
public static string generateRandomVariable(bool onlyDefined)
{
    int val;
    if (onlyDefined)
    {
        int id = random.Next(Gp.definedVariables.Count - 1);
        val = Gp.definedVariables[id];
    }
    else
    {
        val = random.Next(0,6);
        if (!Gp.definedVariables.Contains(val))
            Gp.definedVariables.Add(val);
    }
    
    return "X"+val;
}

public static string generateRandomOperator(){
    int val = random.Next(0,5);
    if(val==0){
        return "=";
    }
    if(val==1){
        return "+=";
    }
    if(val==2){
        return "-=";
    }
    if(val==3){
        return "*=";
    }
    return "/=";
}
public static string generateRandomValueOrVariable(bool onlyDefined){
    int val = random.Next(0,2);
    if(val==0){
        return generateRandomVariable(onlyDefined);
    }
    return generateRandomInt(-1000,1000).ToString();
}
public static string generateRandomComparator(){
    int val = random.Next(0,4);
    if(val==0){
        return "==";
    }
    if(val==1){
        return ">=";
    }
    if(val==2){
        return "!=";
    }
    return "<=";

}

}