class Target
{
    public List<String> Inputs = new();
    public List<String> ExpectedOutputs = new();
    public override string ToString()
    {
        return "Inputs: "+String.Join(", ",this.Inputs) +" Expected: "+ String.Join(", ",this.ExpectedOutputs);
    }
}
