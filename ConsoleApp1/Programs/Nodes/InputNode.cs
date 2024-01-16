public class InputNode:Node{
    public string val;

    public InputNode(){
        this.val = RandomGenerator.generateRandomVariable();
    }
        public override string ToString()
    {
        return $"input({val})\n";
    }
}