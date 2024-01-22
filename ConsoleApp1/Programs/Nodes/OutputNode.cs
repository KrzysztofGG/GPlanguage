public class OutputNode:Node{
    
    public string val;

    public OutputNode(){
        this.val = RandomGenerator.generateRandomValueOrVariable();
    }
        public override string ToString()
    {
        return $"print({val})\n";
    }
}