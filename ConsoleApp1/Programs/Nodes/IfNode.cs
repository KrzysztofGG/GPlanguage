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
        public override string ToString()
    {
        
        string indent = "";
        for(int i=0;i<=this.indentAmount;i++){
            indent+="   ";
        }
        string res = "";
        res+=$"If({condition})";
        res+="{\n";
        foreach(Node n in nodes){
            res+=indent+n.ToString();
        }
        res+=indent.Substring(0, indentAmount)+"}\n";
        return res;
    }
}