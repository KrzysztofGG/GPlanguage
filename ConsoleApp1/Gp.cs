using System.Runtime.CompilerServices;
using System.Security.AccessControl;

static class Gp{

    static int POPULATION_SIZE = 10000;
    static int MAX_GENERATIONS = 100;
    private static int MAX_OPERATIONS = 5;
    private static int FINISH_THRESHOLD = 0;
    public static int MAX_DEPTH = 3;
    private static int GENERATION_NUMBER = 0;
    public static List<double> averageFitnessArr = new List<double>();
    public static List<double> bestFitnessArr = new List<double>();

    private static int OPERATIONS_PER_GENERATION = 8500;
    private static int TOURNAMENT_SIZE = 2;

    public static Random random = new Random();

    public static double MUTATE_CHANCE = 0.25;
    static double CROSSOVER_CHANCE = 0.75;
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
                int good1 = tournamentSelection();
                int good2 = tournamentSelection();
                Individual i1 = population[good1];
                Individual i2 = population[good2];
                
                // Console.WriteLine("PICKED1\n"+i1.program.ToString());
                // Console.WriteLine("PICKED2\n"+i2.program.ToString());
                var (res1, res2) = Individual.cross(i1, i2);
                
                // Console.WriteLine("RES1\n"+res1.program.ToString());
                // Console.WriteLine("RES2\n"+res2.program.ToString());
                int bad1 = negativeSelection();
                int bad2 = negativeSelection();
                // Console.WriteLine(good1 +" " + good2 +" "+ bad1 + " " + bad2);
                
                population[bad1] = res1;
                population[bad2] = res2;
            }
            else
            {
                Individual i1 = population[i];
                i1.program.grow(MAX_DEPTH+5);
            }

            

        }
        // createPopulation();
        // Console.WriteLine(population.Count);
        // Console.WriteLine("BEST:\n"+population[bestSelection()].program);
        
        GENERATION_NUMBER += 1;
        
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
    static void Main(){
        fitness = new Fitness("../../../data/problem.txt");
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
