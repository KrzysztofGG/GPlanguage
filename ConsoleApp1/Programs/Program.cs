using System.Collections;

public class Program{
    public static string[] choices = { "input", "assignment", "if", "while", "output" };
    public List<Node> nodes = new List<Node>(); 

    public Program(){}
    public Program(int depth, int maxNumOfNodes){
        int numOfNodes = RandomGenerator.generateRandomInt(1, maxNumOfNodes);
        for(int i = 0; i<numOfNodes; i++){
            this.nodes.Add(RandomGenerator.generateRandomNode(depth));
        }
    }
    public void grow(int depth){
        for(int i=0;i<this.nodes.Count;i++)
        {
            Random r = new Random();
            if(r.NextDouble()<0.5){
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

    public Program copy()
    {
        Program p = new Program();
        p.nodes = new List<Node>(nodes);
        return p;
    }


}