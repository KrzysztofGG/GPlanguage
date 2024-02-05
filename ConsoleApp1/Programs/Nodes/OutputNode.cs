public class OutputNode:Node{
    
    public string val;

    public OutputNode(){
        this.val = RandomGenerator.generateRandomVariable();
    }
        public override string ToString()
    {
        return $"print({val})\n";
    }
}