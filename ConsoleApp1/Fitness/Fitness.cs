public class Fitness{
    static double punishment = 100000;
    static double mult_punishment = 100;
    List<Target> targets;

    public Fitness(string filename){
        targets = new List<Target>();

        var lines = System.IO.File.ReadAllLines(filename);
        foreach(var line in lines){
            var target = new Target();
            var slice = line.Split(":");
            target.Inputs = new();
            foreach(var input in slice[0].Trim().Split(" ")){
                target.Inputs.Add(input);
            }
            target.ExpectedOutputs = new();
            foreach(var output in slice[1].Trim().Split(" ")){
                target.ExpectedOutputs.Add(output);
            }
            targets.Add(target);
        }
        // foreach(Target t in targets){
        //     Console.WriteLine(t);
        // }
    }

    public double calculateFitness(Individual individual){
        double fitness = 0;
        
        foreach(var target in targets)
        {
            // Console.WriteLine(individual.program);
            var output = individual.Run(target.Inputs);
            fitness += evaluate(output, target.ExpectedOutputs);
        }

        if (fitness == 0) {
            int x = 123;
        }

        // Console.WriteLine("FITNESS: "+fitness);
        individual.fitness = fitness;
        return fitness;
    }

    public double evaluate(List<string> outputs, List<string> expectedOutputs){
        double res = 0;
        if (outputs.Count == 0)
        {
            res += 100000;
        }
        if (outputs.Count != expectedOutputs.Count)
        {
            res += 1000;
        }
        for(int i=0; i< Math.Max(expectedOutputs.Count, outputs.Count); i++){
            if(i>= outputs.Count || i>=expectedOutputs.Count){
                res += punishment;
            }
            else{
                res += 1000 * Math.Abs(Int32.Parse(outputs[i]) - Int32.Parse(expectedOutputs[i]));
            }
        }
        return res;
    }
}