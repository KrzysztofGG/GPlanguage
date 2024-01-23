using Antlr4.Runtime;
using ConsoleApp1.Content;

public class Individual{
    public Program program;
    public double fitness;
    public static Random random = new Random();
    public Individual(){}
    public Individual(int maxDepth, int numOfNodes){
        program = new Program(maxDepth, numOfNodes);
        fitness = Gp.fitness.calculateFitness(this);
    }

    public Individual(Program program)
    {
        this.program = program;
        fitness = Gp.fitness.calculateFitness(this);
    }
    public List<String> Run(List<String> inputs){

        AntlrInputStream inputStream = new AntlrInputStream(program.ToString());
        MyGrammarLexer myGrammarLexer = new MyGrammarLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(myGrammarLexer);
        MyGrammarParser myGrammarParser = new MyGrammarParser(commonTokenStream);

        MyGrammarParser.ProgramContext programContext = myGrammarParser.program();

        MyGrammarVisitor myGrammarVisitor = new MyGrammarVisitor(inputs, -1);
        var res = myGrammarVisitor.visitWithOutput(programContext);

        return res;
    }

    public static (Individual, Individual) cross(Individual i1, Individual i2)
    {
        var i1_copy = i1.copy();
        var i2_copy = i2.copy();
        for (int i = 0; i < Math.Min(i1_copy.program.nodes.Count, i2_copy.program.nodes.Count); i++)
        {
            Double choice = random.Next();
            if (choice < 0.5)
            {
                if (choice < 0.25)
                {
                    i1_copy.program.nodes[i] = i2_copy.program.nodes[i];
                }
                else
                {
                    i2_copy.program.nodes[i] = i1_copy.program.nodes[i];
                }
                
            }
            else
            {
                // i2_copy.program.nodes[i] = RandomGenerator.generateRandomNode(2);
                // i1_copy.program.nodes[i] = RandomGenerator.generateRandomNode(2);
            }
        }
        return (i1, i2);
    }

    public Individual copy()
    {
        Individual i = new Individual();
        i.program = program.copy();
        return i;
    }
}