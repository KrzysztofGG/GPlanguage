using System.Collections;

public class Program{
    public string[] choices = { "input", "assignment", "if", "while", "output" };
    public List<Node> nodes = new List<Node>(); 

    public Program(int depth, int maxNumOfNodes){
        int numOfNodes = RandomGenerator.generateRandomInt(1, maxNumOfNodes);
        // for(int i =0;i<6;i++){
        //     this.nodes.Add(new InputNode(i));
        // }
        for(int i = 0; i<numOfNodes; i++){
            this.nodes.Add(RandomGenerator.generateRandomNode(depth));
        }
    }

    public Program(List<Node> nodes)
    {
        this.nodes = nodes;
    }
    public void grow(int depth){
        for(int i=0;i<this.nodes.Count;i++){
            int val = RandomGenerator.generateRandomInt(0,100);
            if(val<=Gp.MUTATE_CHANCE){
                this.nodes[i] = RandomGenerator.generateRandomNode(depth);
            }
        }
    }

    public static (Program, Program) Crossover(Program parent1, Program parent2)
    {
        var offspring1 = new Program(parent1.nodes);
        var offspring2 = new Program(parent1.nodes);

        var pos1 = RandomGenerator.generateRandomInt(0, offspring1.nodes.Count - 1);
        var pos2 = RandomGenerator.generateRandomInt(0, offspring2.nodes.Count - 1);

        var crossover_point1 = offspring1.nodes[pos1];
        var crossover_point2 = offspring1.nodes[pos2];

        offspring1.nodes[pos1] = crossover_point2;
        offspring2.nodes[pos2] = crossover_point1;

        // var newIndividual1 = new Individual(offspring1);
        // var newIndividual2 = new Individual(offspring2);
        // return (newIndividual1, newIndividual2);
        return (offspring1, offspring2);
    }

    public void Mutate()
    {
        var randomIndex = RandomGenerator.generateRandomInt(0, this.nodes.Count - 1);
        this.nodes[randomIndex] = RandomGenerator.generateRandomNode(Gp.MAX_DEPTH);
    }
    
    
    // public Program DeepCopy(){}
    public override string ToString()
    {
        string res = "";
        foreach(Node n in this.nodes){
            res+=n.ToString();
        }
        return res;
    }
}