public class InputNode:Node{
    public string val;

    public InputNode(){
        this.val = RandomGenerator.generateRandomVariable();
    }
    public InputNode(int num){
        this.val = "X"+num;
    }

    public InputNode(string val)
    {
        this.val = val;
    }
    
        public override string ToString()
    {
        return $"scan({val})\n";
    }
}