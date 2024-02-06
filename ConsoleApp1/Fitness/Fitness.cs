using System.Globalization;

public class Fitness{
    static double punishment = 10000;
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
                target.Inputs.Add(double.Parse(input, CultureInfo.InvariantCulture));
            }
            target.ExpectedOutputs = new();
            foreach(var output in slice[1].Trim().Split(" ")){
                target.ExpectedOutputs.Add(double.Parse(output, CultureInfo.InvariantCulture));
            }
            targets.Add(target);
        }

    }

    public double calculateFitness(Individual individual){
        double fitness = 0;
        
        foreach(var target in targets)
        {
            var output = individual.Run(target.Inputs);
            fitness += evaluate(output, target.ExpectedOutputs);
        }

        if (fitness == 0) {
            int x = 123;
        }
        
        individual.fitness = fitness;
        return fitness;
    }

    public double evaluate(List<double> outputs, List<double> expectedOutputs){
        // if (expectedOutputs.Contains("specific"))
        // {
        //     return evaluateSpecificIndex(outputs, expectedOutputs);
        // }
        //
        // if (expectedOutputs.Contains("any"))
        // {
        //     return evaluateAnyNumberOfOutputs(outputs, expectedOutputs);
        // }

        return evaluateGivenNumberOfOutputs(outputs, expectedOutputs);

    }

    public double evaluateSpecificIndex(List<string> outputs, List<string> expectedOutputs)
    {
        double res = 0;
        if (outputs.Count != 0)
        {
            double expectedAtIndex = double.Parse(expectedOutputs[0]);
            double outputAtIndex = double.Parse(outputs[0]);
            return Math.Abs(expectedAtIndex - outputAtIndex);
        }

        return punishment*10;
    }

    public double evaluateAnyNumberOfOutputs(List<string> outputs, List<string> expectedOutputs, Dictionary<int, String> expectedIndexes = null)
    {
        double res = 0;
        if (outputs.Count != 0){
            List<double> doubleList = outputs.Select(s => double.Parse(s)).ToList();
            var expectedVal = double.Parse(expectedOutputs[0]);
            double closestVal = findClosestValue(doubleList, expectedVal);
            return Math.Abs(closestVal - expectedVal)*100;
        }

        return punishment*10;
    }

    public double evaluateGivenNumberOfOutputs(List<double> outputs, List<double> expectedOutputs)
    {
        double res = 0;
        if (outputs.Count == 0)
        {
            res += punishment;
            return res * 10;
        }
        if (outputs.Count != expectedOutputs.Count)
        {
            res += punishment;
        }
        for(int i=0; i< Math.Max(expectedOutputs.Count, outputs.Count); i++){
            if(i>= outputs.Count || i>=expectedOutputs.Count){
                res += punishment;
            }
            else{
                // res += Math.Abs(double.Parse(outputs[i]) - double.Parse(expectedOutputs[i]));
                res += Math.Abs(outputs[i] - expectedOutputs[i]);
            }
        }
        return res;
    }

    public double findClosestValue(List<double> numbers, double target)
    {
        var closestNumber = numbers.OrderBy(x => Math.Abs(x - target)).First();
        return closestNumber;
    }
}