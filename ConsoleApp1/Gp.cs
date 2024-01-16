static class Gp{

    static int POPULATION_SIZE = 100;
    static int MAX_GENERATIONS = 10;
    static int MAX_OPERATIONS = 200;
    public static int MAX_DEPTH = 3;

    public static int MUTATE_CHANCE = 25;
    static int CROSSOVER_CHANCE = 50;
    static void Main(){
        Fitness f = new Fitness("./data/data.txt");
        // Program program = new Program(MAX_DEPTH,5);
        // Console.WriteLine(program);
        
    }
}
