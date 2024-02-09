public class AssignmentNode:Node{

    public String firstVal;
    public String secodnVal;
    public String operand;
    public AssignmentNode(){
        this.firstVal = RandomGenerator.generateRandomVariable();
        Random random = new Random();
        // this.operand = "=";
        this.operand = "=";
        if (random.NextDouble() <= 0.5)
        {

            this.secodnVal = RandomGenerator.generateRandomValueOrVariable();
        }
        else
        {
            this.secodnVal = RandomGenerator.generateRandomValueOrVariable() +
                             RandomGenerator.generateRandomOperator() + RandomGenerator.generateRandomValueOrVariable();
        }


        // this.operand = RandomGenerator.generateRandomOperator();
        // this.secodnVal = RandomGenerator.generateRandomValueOrVariable();
    }

    public AssignmentNode(string firstVal, string secodnVal)
    {
        this.firstVal = firstVal;
        this.secodnVal = secodnVal;
        this.operand = "=";
    }

    public override string ToString()
    {
        return $"{firstVal}{operand}{secodnVal}\n";
    }

}