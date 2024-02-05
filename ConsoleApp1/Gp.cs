using System.Runtime.CompilerServices;
using System.Security.AccessControl;

static class Gp{

    static int POPULATION_SIZE = 10000;
    static int MAX_GENERATIONS = 1000;
    public static int MAX_OPERATIONS = 5;
    private static int FINISH_THRESHOLD = 0;
    public static int MAX_DEPTH = 2;
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
    public static void createPopulation()
    {
        for (int i = 0; i < POPULATION_SIZE; i++)
        {
            population.Add(new Individual(MAX_DEPTH,MAX_OPERATIONS));
        }
        
    }

    public static void runEvolve()
    {
        
        for (int i = 0; i < MAX_GENERATIONS; i++)
        {
            if (i != 0)
            {
                evolveGeneration();
            }
            
            gradeGeneration();
            if (bestIndividual.fitness <= FINISH_THRESHOLD)
            {
                break;
            }
        }

        printFoundSolution();

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

    public static void gradeGeneration()
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
        Console.WriteLine($"GENERATION {GENERATION_NUMBER} AVERAGE FITNESS {averageFitness} BEST FITNESS: {bestIndividual.fitness}");
        Console.WriteLine("BEST INDIVIDUAL:");
        Console.WriteLine(bestIndividual.program);
    }

    public static void printFoundSolution()
    {
        Console.WriteLine("FOUND SOLUTION:");
        Console.WriteLine(bestIndividual.program);
    }

    
    static void Main(){
        fitness = new Fitness("../../../data/final_boolean_6.txt");
        createPopulation();
        runEvolve();
        SaveListToCsv(averageFitnessArr, "./average.txt");
        SaveListToCsv(bestFitnessArr, "./best.txt");

        // Program p1 = new Program(1, 5);
        // Program p2 = new Program(1, 5);
        // Console.WriteLine(p1);
        // Console.WriteLine("==========");
        // p1.Mutate();
        // Console.WriteLine(p1);
        //
        // p1.Mutate();
        // var (res1, res2) = Program.Crossover(p1, p2);
        //

        // Console.WriteLine(p2);
        // Console.WriteLine("==========");
        // Console.WriteLine(res1);
        // Console.WriteLine("==========");
        // Console.WriteLine(res2);



    }
    static void SaveListToCsv(List<double> list, string filePath)
    {
        try
        {
            string csvLine = "val\n";

             csvLine += string.Join("\n", list);


            File.WriteAllText(filePath, csvLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
