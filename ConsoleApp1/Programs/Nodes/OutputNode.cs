public class OutputNode:Node{
    
    public string val;

    public OutputNode(){
        this.val = RandomGenerator.generateRandomValueOrVariable();
    }
        public override string ToString()
    {
        return $"output({val})\n";
    }
}