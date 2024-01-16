using Antlr4.Runtime;
using ConsoleApp1.Content;

public class Individual{
    public Program program;
    public List<String> Run(List<String> inputs){
        // return new List<string>();
        AntlrInputStream inputStream = new AntlrInputStream(program.ToString());
        MyGrammarLexer myGrammarLexer = new MyGrammarLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(myGrammarLexer);
        MyGrammarParser myGrammarParser = new MyGrammarParser(commonTokenStream);

        MyGrammarParser.ProgramContext programContext = myGrammarParser.program();

        MyGrammarVisitor myGrammarVisitor = new MyGrammarVisitor(inputs, 16);
        // myGrammarVisitor.Visit(programContext);
        return myGrammarVisitor.visitWithOutput(programContext);
    }
}