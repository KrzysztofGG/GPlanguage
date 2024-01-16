public class AssignmentNode:Node{

    String firstVal;
    String secodnVal;
    String operand;
    public AssignmentNode(){
        this.firstVal = RandomGenerator.generateRandomVariable();
        this.operand = RandomGenerator.generateRandomOperator();
        this.secodnVal = RandomGenerator.generateRandomInt(-1000,1000).ToString();
    }

    public override string ToString()
    {
        return $"{firstVal}{operand}{secodnVal}\n";
    }

}