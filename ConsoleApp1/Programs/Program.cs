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

    public Program(List<Node> nodes)
    {
        this.nodes = new List<Node>(nodes);
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

    public static (Program, Program) Crossover(Program parent1, Program parent2)
    {
        var offspring1 = new Program(parent1.nodes);
        var offspring2 = new Program(parent2.nodes);

        var pos1 = RandomGenerator.generateRandomInt(0, offspring1.nodes.Count - 1);
        var pos2 = RandomGenerator.generateRandomInt(0, offspring2.nodes.Count - 1);
        
        var crossoverList1 = offspring1.nodes.GetRange(pos1, offspring1.nodes.Count - pos1);
        var crossoverList2 = offspring2.nodes.GetRange(pos2, offspring2.nodes.Count - pos2);
        
        offspring1.nodes.RemoveRange(pos1, offspring1.nodes.Count - pos1);
        offspring1.nodes.InsertRange(pos1, crossoverList2);
        
        offspring2.nodes.RemoveRange(pos2, offspring2.nodes.Count - pos2);
        offspring2.nodes.InsertRange(pos2, crossoverList1);
        
        // var crossover_point1 = offspring1.nodes[pos1];
        // var crossover_point2 = offspring1.nodes[pos2];
        
        // offspring1.nodes[pos1] = crossover_point2;
        // offspring2.nodes[pos2] = crossover_point1;
        
        return (offspring1, offspring2);
    }

    public void Mutate()
    {

        var mutationBasis = new Individual(Gp.MAX_DEPTH, Gp.MAX_OPERATIONS);
        var basisIndex = RandomGenerator.generateRandomInt(0, mutationBasis.program.nodes.Count - 1);
        var mutationElements = mutationBasis.program.nodes.GetRange(basisIndex,
            mutationBasis.program.nodes.Count - basisIndex);
        
        var randomIndex = RandomGenerator.generateRandomInt(0, this.nodes.Count - 1);
        this.nodes.RemoveRange(randomIndex, this.nodes.Count - randomIndex);
        this.nodes.InsertRange(randomIndex, mutationElements);
        
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