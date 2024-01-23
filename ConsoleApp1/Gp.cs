using System.Runtime.CompilerServices;
using System.Security.AccessControl;

static class Gp{

    static int POPULATION_SIZE = 20;
    static int MAX_GENERATIONS = 100;
    private static int MAX_OPERATIONS = 3;
    private static int FINISH_THRESHOLD = 0;
    public static int MAX_DEPTH = 3;
    private static int GENERATION_NUMBER = 0;
    public static List<double> averageFitnessArr = new List<double>();
    public static List<double> bestFitnessArr = new List<double>();
    
    private static int OPERATIONS_PER_GENERATION = 850;
    private static int TOURNAMENT_SIZE = 2;

    public static Random random = new Random();

    public static double MUTATE_CHANCE = 0.25;
    static double CROSSOVER_CHANCE = 0.25;
    public static List<Individual> population = new List<Individual>();
    public static Individual bestIndividual;
    public static Fitness fitness;


    public static int inputSize = 0;
    public static List<int> definedVariables = new List<int>();

    private static void setInputSize(string file)
    {
        var line = System.IO.File.ReadLines(file).First();
        var slice = line.Split(":");
        inputSize = slice[0].Trim().Split(" ").Length;
        for(int i=0; i<inputSize; ++i)
            definedVariables.Add(i);
        // definedVariables = inputSize;

    }
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

            bestIndividual = null;
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
                var parent = population[TournamentSelection()];
                var child = new Program(parent.program.nodes);

                child.Mutate();
                population[NegativeTournamentSelection()] = new Individual(child);
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

    public static int tournamentSelection()
    {
        int bestIndex = random.Next(POPULATION_SIZE);
        for (int i = 0; i < TOURNAMENT_SIZE; i++)
        {
            int randomIndex = random.Next(POPULATION_SIZE);
            if (population[randomIndex].fitness < population[bestIndex].fitness)
            {
                bestIndex = randomIndex;
            }
        }

        return bestIndex;
    }

    public static int negativeSelection()
    {
        int worstIndex = random.Next(POPULATION_SIZE);
        for (int i = 0; i < TOURNAMENT_SIZE; i++)
        {
            int randomIndex = random.Next(POPULATION_SIZE);
            if (population[randomIndex].fitness > population[worstIndex].fitness)
            {
                worstIndex = randomIndex;
            }
        }

        return worstIndex;
    }

    public static int bestSelection()
    {
        int bestIndex = 0;
        for (int i = 1; i < POPULATION_SIZE; i++)
        {
            if (population[i].fitness < population[bestIndex].fitness)
            {
                bestIndex = i;
            }
        }

        return bestIndex;
    }
    static void Main()
    {
        var filePath = "../../../data/problem7.txt";
        fitness = new Fitness(filePath);
        setInputSize(filePath);
        createPopulation();
        runEvolve();
        SaveListToCsv(averageFitnessArr, "./average.txt");
        SaveListToCsv(bestFitnessArr, "./best.txt");


    }
    static void SaveListToCsv(List<double> list, string filePath)
    {
        try
        {
            string csvLine = "val\n";
            for(int i=0;i<list.Count;i++){}
            // Convert each integer to a string and join them with commas
             csvLine += string.Join("\n", list);

            // Write the CSV line to the file
            File.WriteAllText(filePath, csvLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
