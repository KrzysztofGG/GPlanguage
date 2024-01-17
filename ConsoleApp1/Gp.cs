using System.Runtime.CompilerServices;

static class Gp{

    static int POPULATION_SIZE = 100;
    static int MAX_GENERATIONS = 10;
    static int MAX_OPERATIONS = 200;
    private static int FINISH_THRESHOLD = 1000;
    public static int MAX_DEPTH = 3;
    private static int GENERATION_NUMBER = 0;
    

    public static int MUTATE_CHANCE = 25;
    static int CROSSOVER_CHANCE = 50;
    public static List<Individual> population = new List<Individual>();
    public static Individual bestIndividual;
    public static Fitness fitness;
    public static void createPopulation()
    {
        for (int i = 0; i < POPULATION_SIZE; i++)
        {
            population.Add(new Individual(MAX_DEPTH,RandomGenerator.generateRandomInt(1,5)));
        }
        
    }

    public static void runEvolve()
    {
        
        for (int i = 0; i < MAX_GENERATIONS; i++)
        {
            evolveGeneration();
            gradeGeneration();
            if (bestIndividual.fitness < FINISH_THRESHOLD)
            {
                break;
            }
        }

        printFoundSolution();

    }

    public static void evolveGeneration()
    {
        foreach (var individual in population)
        {
            individual.program.grow(MAX_DEPTH + RandomGenerator.generateRandomInt(1,5));
        }
    }

    public static void gradeGeneration()
    {
        double fitnessSum = 0;
        foreach (var individual in population)
        {
            fitness.calculateFitness(individual);
            fitnessSum += individual.fitness;
            if (bestIndividual == null || individual.fitness > bestIndividual.fitness)
            {
                bestIndividual = individual;
            }
        }

        var averageFitness = fitnessSum / POPULATION_SIZE;
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
        fitness = new Fitness("../../../data/data.txt");
        createPopulation();
        runEvolve();

        // Individual i = new Individual(MAX_DEPTH, 5);
        // Console.WriteLine(i.program);

        // f.calculateFitness(i);
        // Program program = new Program(MAX_DEPTH,5);
        // Console.WriteLine(program);
        // List<string> inputs = new List<string>();
        // inputs.Add("10");
        // inputs.Add("10");
        // inputs.Add("10");
        // inputs.Add("10");
        // inputs.Add("10");
        // inputs.Add("10");
        //
        // Individual i = new Individual(MAX_DEPTH, 5);
        // Console.WriteLine(i.program);
        // List<String> output= i.Run(inputs);
        // foreach(string s in output){
        //     Console.WriteLine(s);
        // }


    }
}
