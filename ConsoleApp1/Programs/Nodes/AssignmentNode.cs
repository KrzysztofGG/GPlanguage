public class AssignmentNode:Node{

    String firstVal;
    String secodnVal;
    String operand;
    public AssignmentNode(){
        this.firstVal = RandomGenerator.generateRandomVariable();
        // this.operand = "=";
        this.operand = RandomGenerator.generateRandomOperator();
        this.secodnVal = RandomGenerator.generateRandomValueOrVariable();
    }

    public override string ToString()
    {
        return $"{firstVal}{operand}{secodnVal}\n";
    }

}