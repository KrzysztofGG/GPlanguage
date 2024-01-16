public class Fitness{
    static double punishment = 1e12;
    static double mult_punishment = 1e6;
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
        foreach(Target t in targets){
            Console.WriteLine(t);
        }
    }

    public double calculateFitness(Individual individual){
        double fitness = 0;
        foreach(var target in targets){
            var output = individual.Run(target.Inputs);
            fitness -= evaluate(output, target.ExpectedOutputs);
        }
        return fitness;
    }

    public double evaluate(List<string> outputs, List<string> expectedOutputs){
        double res = 0;
        for(int i=0; i< expectedOutputs.Count; i++){
            if(i>= outputs.Count){
                res += punishment;
            }
            else{
                res += punishment * Math.Abs(Int32.Parse(outputs[i]) - Int32.Parse(expectedOutputs[i]));
            }
        }
        return res;
    }
}