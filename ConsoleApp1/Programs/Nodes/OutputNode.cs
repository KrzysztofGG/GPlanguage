public class OutputNode:Node{
    
    public string val;

    public OutputNode(){
        this.val = RandomGenerator.generateRandomVariable();
    }
    public OutputNode(string val)
    {
        this.val = val;
    }
        public override string ToString()
    {
        return $"print({val})\n";
    }
}