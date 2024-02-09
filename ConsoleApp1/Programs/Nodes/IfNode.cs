public class IfNode:Node{
    BooleanNode condition;
    public List<Node> nodes = new List<Node>(); 
    int indentAmount;

    public IfNode(int depth){
        this.indentAmount = Gp.MAX_DEPTH - depth;
        this.condition = new BooleanNode();

        int numOfNodes = RandomGenerator.generateRandomInt(2,5);
        
        for(int i=0;i<numOfNodes;i++){
            int randomdepth = RandomGenerator.generateRandomInt(0,depth-1);
            this.nodes.Add(RandomGenerator.generateRandomNode(randomdepth));
        }

    }

    public IfNode(List<Node> nodes, BooleanNode condition)
    {
        this.nodes = nodes;
        this.condition = condition;
        this.indentAmount = 1;
    }
        public override string ToString()
    {
        
        string indent = "";
        for(int i=0;i<=this.indentAmount;i++){
            indent+="   ";
        }
        string res = "";
        res+=$"if({condition})";
        res+="{\n";
        foreach(Node n in nodes){
            res+=indent+n.ToString();
        }
        
        res+=indent.Substring(0, Math.Max(indentAmount,0))+"}\n";
        return res;
    }
}