using System.Collections;

public class Program{
    public string[] choices = { "input", "assignment", "if", "while", "output" };
    public List<Node> nodes = new List<Node>(); 

    public Program(int depth, int maxNumOfNodes){
        int numOfNodes = RandomGenerator.generateRandomInt(1, maxNumOfNodes);
        for(int i =0;i<6;i++){
            this.nodes.Add(new InputNode(i));
        }
        for(int i = 0; i<numOfNodes; i++){
            this.nodes.Add(RandomGenerator.generateRandomNode(depth));
        }
    }
    public void grow(int depth){
        for(int i=0;i<this.nodes.Count;i++){
            int val = RandomGenerator.generateRandomInt(0,100);
            if(val<=Gp.MUTATE_CHANCE){
                this.nodes[i] = RandomGenerator.generateRandomNode(depth);
            }
        }
    }
    
    public override string ToString()
    {
        string res = "";
        foreach(Node n in this.nodes){
            res+=n.ToString();
        }
        return res;
    }
}