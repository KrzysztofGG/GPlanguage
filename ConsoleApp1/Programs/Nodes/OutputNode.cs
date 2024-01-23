public class OutputNode:Node{
    
    public string val;

    public OutputNode(){
        this.val = RandomGenerator.generateRandomValueOrVariable(true);
    }
        public override string ToString()
    {
        return $"print({val})\n";
    }
}