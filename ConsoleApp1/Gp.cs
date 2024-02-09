using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;

static class Gp{

    static int POPULATION_SIZE = 10000;
    static int MAX_GENERATIONS = 1000;
    public static int MAX_OPERATIONS = 5;
    private static int FINISH_THRESHOLD = 0;
    public static int MAX_DEPTH = 3;
    private static int GENERATION_NUMBER = 0;
    public static List<double> averageFitnessArr = new List<double>();
    public static List<double> bestFitnessArr = new List<double>();

    private static int OPERATIONS_PER_GENERATION = 7000;
    private static int TOURNAMENT_SIZE = 2;

    public static Random random = new Random();
    
    static double CROSSOVER_CHANCE = 0.5;
    public static List<Individual> population = new List<Individual>();
    public static Individual bestIndividual;
    public static Fitness fitness;
    static void saveProblem(string fileName)
    {
        fileName = fileName.Substring(0, fileName.Length - 4);
        
        if(!Directory.Exists(($"../../../data/rozwiazania/{fileName}")))
        {
            Directory.CreateDirectory($"../../../data/rozwiazania/{fileName}");
        }
        string path = $"../../../data/rozwiazania/{fileName}/solution";
        try
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"POPULATION_SIZE = {POPULATION_SIZE}");
                sw.WriteLine($"MAX_GENERATIONS = {MAX_GENERATIONS}");
                sw.WriteLine($"MAX_OPERATIONS = {MAX_OPERATIONS}");
                sw.WriteLine($"FINISH_THRESHOLD = {FINISH_THRESHOLD}");
                sw.WriteLine($"MAX_DEPTH = {MAX_DEPTH}");
                sw.WriteLine($"OPERATIONS_PER_GENERATION = {OPERATIONS_PER_GENERATION}");
                sw.WriteLine($"TOURNAMENT_SIZE = {TOURNAMENT_SIZE}");
                sw.WriteLine($"CROSSOVER_CHANCE = {CROSSOVER_CHANCE}");
                sw.WriteLine($"GENERATIONS = {GENERATION_NUMBER}\n");
                
                sw.WriteLine("FOUND SOLUTION:\n" + bestIndividual.program);
            }
            
            SaveListToCsv(averageFitnessArr, $@"../../../data/rozwiazania/{fileName}/average.txt");
            SaveListToCsv(bestFitnessArr, $@"../../../data/rozwiazania/{fileName}/best.txt");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static void createPopulation()
    {
        for (int i = 0; i < POPULATION_SIZE; i++)
        {
            population.Add(new Individual(MAX_DEPTH,MAX_OPERATIONS));
        }
        
    }

    public static void createPopulationFromFile(string fileName)
    {
        List<Node> programNodes = deserializeFile(fileName);
        for (var i=0; i<programNodes.Count; ++i)
        {
            population.Add(new Individual(new Program(programNodes)));
        }

    }

    public static List<Node> deserializeFile(string fileName)
    {
        List<Node> programNodes = new List<Node>();
        using (var fileStream = File.OpenRead(fileName))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
        {
            String line;
            List<Node> nodesForSpecial = new List<Node>();
            String specialLine = "";
            Node newNode = null;
            while ((line = streamReader.ReadLine()) != null && line != "")
            {
                if (line.Contains("while") || line.Contains("if"))
                {
                    specialLine = line;
                }
                else if (line.Contains("scan"))
                    newNode = createReadWriteNode(line, true);
                else if (line.Contains("print"))
                    newNode = createReadWriteNode(line, false);
                else if (line.Contains("}"))
                {
                    if (specialLine.Contains("while"))
                    {
                        WhileNode whileNode = (WhileNode)createSpecialNode(specialLine, true);
                        whileNode.nodes = nodesForSpecial;
                        programNodes.Add(whileNode);
                    }
                    else if (specialLine.Contains("if"))
                    {
                        IfNode ifNode = (IfNode)createSpecialNode(specialLine, false);
                        ifNode.nodes = nodesForSpecial;
                        programNodes.Add(ifNode);
                    }

                    nodesForSpecial = new List<Node>();
                    specialLine = "";
                }
                else
                    newNode = createAssignmentNode(line);

                if (specialLine.Length > 0 && newNode != null)
                {
                    nodesForSpecial.Add(newNode);
                    newNode = null;
                }
                else if (newNode != null)
                {
                    programNodes.Add(newNode);
                    newNode = null;
                }
            }
        }

        return programNodes;
    }

    public static Node createAssignmentNode(String line)
    {
        var firstVal = line.Substring(line.IndexOf("X"), line.IndexOf("=") - line.IndexOf("X"));
        var secondVal = line.Substring(line.IndexOf("=") + 1);
        return new AssignmentNode(firstVal, secondVal);
    }
    public static Node createReadWriteNode(String line, bool isScan)
    {
        Node outNode;
        var val = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1);
        if (isScan)
            outNode = new InputNode(val);
        else
            outNode = new OutputNode(val);
        return outNode;

    }
    public static Node createSpecialNode(String line, bool isWhileNode)
    {
        Node outNode;
        line = line.Substring(line.IndexOf("(", StringComparison.Ordinal)+1);
        var firstVal = line.Substring(0, line.IndexOf(" "));
        var comparator = line.Substring(line.IndexOf(" ") + 1, 2);
        var secondVal = line.Substring(line.IndexOf(" ")+4, line.IndexOf(")") - (line.IndexOf(" ")+4));
        BooleanNode booleanNode = new BooleanNode(firstVal, secondVal, comparator);
        if (isWhileNode)
            outNode = new WhileNode(new List<Node>(), booleanNode);
        else
            outNode = new IfNode(new List<Node>(), booleanNode);
        return outNode;
    }
    public static void runEvolve(string fileName)
    {
        for (int i = 0; i < MAX_GENERATIONS; i++)
        {
            if (i != 0)
            {
                evolveGeneration();
            }
            
            gradeGeneration(fileName);
            if (bestIndividual.fitness <= FINISH_THRESHOLD)
            {
                break;
            }
        }

        printFoundSolution(fileName);

    }

    public static void evolveGeneration()
    {
        // createPopulation();
        
        for (int i = 0; i < POPULATION_SIZE; i++)
        {
            if (random.NextDouble() < CROSSOVER_CHANCE)
            {
                var parent1 = population[TournamentSelection()];
                var parent2 = population[TournamentSelection()];
                
                var (child1, child2) = Program.Crossover(parent1.program, parent2.program);

                population[NegativeTournamentSelection()] = new Individual(child1);
                population[NegativeTournamentSelection()] = new Individual(child2);
            }
            else
            {
                var parent = population[NegativeTournamentSelection()];
                parent.program.Mutate();
                
                // var child = new Program(parent.program.nodes);

                // child.Mutate();
                // population[NegativeTournamentSelection()] = new Individual(child);
            }
        }
        GENERATION_NUMBER += 1;
    }
    
    
    public static int TournamentSelection()
    {
        int bestIndex = RandomGenerator.generateRandomInt(0, POPULATION_SIZE-1);
        for (int i = 1; i < TOURNAMENT_SIZE; ++i)
        {
            int index = RandomGenerator.generateRandomInt(0, POPULATION_SIZE-1);
            if (population[index].fitness < population[bestIndex].fitness)
                bestIndex = index;
        }

        return bestIndex;
    }

    public static int NegativeTournamentSelection()
    {
        int worstIndex = RandomGenerator.generateRandomInt(0, POPULATION_SIZE-1);
        for (int i = 0; i < TOURNAMENT_SIZE; ++i)
        {
            int index = RandomGenerator.generateRandomInt(0, POPULATION_SIZE-1);
            if (population[index].fitness > population[worstIndex].fitness)
                worstIndex = index;
        }

        return worstIndex;
    }

    public static void gradeGeneration(String fileName)
    {
        double fitnessSum = 0;
        foreach (var individual in population)
        {
            fitness.calculateFitness(individual);
            fitnessSum += individual.fitness;
            if (bestIndividual == null || individual.fitness < bestIndividual.fitness)
            {
                bestIndividual = individual;
            }
        }

        var averageFitness = fitnessSum / POPULATION_SIZE;
        averageFitnessArr.Add(averageFitness);
        bestFitnessArr.Add(bestIndividual.fitness);

        if (GENERATION_NUMBER > 10)
        {
            saveProblem(fileName);
        }
        
        Console.WriteLine($"GENERATION {GENERATION_NUMBER} AVERAGE FITNESS {averageFitness} BEST FITNESS: {bestIndividual.fitness}");
        Console.WriteLine("BEST INDIVIDUAL:");
        Console.WriteLine(bestIndividual.program);
    }

    public static void printFoundSolution(string fileName)
    {
        Console.WriteLine("FOUND SOLUTION:");
        Console.WriteLine(bestIndividual.program);
    }

    
    static void Main()
    {
        var file = "book_problem_21.txt";
        fitness = new Fitness($"../../../data/problems/{file}");
        // createPopulation();
        createPopulationFromFile("C:\\Users\\krzys\\Desktop\\GPlanguage\\ConsoleApp1\\data\\rozwiazania\\prob\\solution");
        runEvolve(file);
        saveProblem(file);
    }
    
    


    static void SaveListToCsv(List<double> list, string filePath)
    {
        Console.WriteLine("SAVING");
        try
        {
            string csvLine = "";

            csvLine += string.Join("\n", list);
            
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(csvLine);
            }	   
            // File.WriteAllText(filePath, csvLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
