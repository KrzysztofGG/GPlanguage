class Target
{
    public List<Double> Inputs = new();
    public List<double> ExpectedOutputs = new();
    public override string ToString()
    {
        return "Inputs: "+String.Join(", ",this.Inputs) +" Expected: "+ String.Join(", ",this.ExpectedOutputs);
    }
}
