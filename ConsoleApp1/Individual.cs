using Antlr4.Runtime;
using ConsoleApp1.Content;

public class Individual{
    public Program program;
    public double fitness;
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
        // return new List<string>();
        AntlrInputStream inputStream = new AntlrInputStream(program.ToString());
        MyGrammarLexer myGrammarLexer = new MyGrammarLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(myGrammarLexer);
        MyGrammarParser myGrammarParser = new MyGrammarParser(commonTokenStream);

        MyGrammarParser.ProgramContext programContext = myGrammarParser.program();

        MyGrammarVisitor myGrammarVisitor = new MyGrammarVisitor(inputs, 16);
        // myGrammarVisitor.Visit(programContext);
        // Console.WriteLine("----");
        var res = myGrammarVisitor.visitWithOutput(programContext);
        // Console.WriteLine(res);
        return res;
    }
}