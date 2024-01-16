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
}