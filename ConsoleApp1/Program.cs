// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using ConsoleApp1.Content;

var fileName = "Content\\test.txt";

var fileContents = File.ReadAllText(fileName);

AntlrInputStream inputStream = new AntlrInputStream(fileContents);
MyGrammarLexer myGrammarLexer = new MyGrammarLexer(inputStream);
CommonTokenStream commonTokenStream = new CommonTokenStream(myGrammarLexer);
MyGrammarParser myGrammarParser = new MyGrammarParser(commonTokenStream);

MyGrammarParser.ProgramContext programContext = myGrammarParser.program();
var input = new List<string>()
{
    "input1",
    "input2",
    "input3",
};
MyGrammarVisitor myGrammarVisitor = new MyGrammarVisitor(input, 3);
myGrammarVisitor.Visit(programContext);
