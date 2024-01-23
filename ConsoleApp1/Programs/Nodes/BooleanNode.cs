public class BooleanNode:Node{

    String firstVal;
    String secondVal;
    String comparator;
    public BooleanNode(){
        // this.firstVal = RandomGenerator.generateRandomValueOrVariable();
        // this.secodnVal = RandomGenerator.generateRandomValueOrVariable();
        this.firstVal = RandomGenerator.generateRandomValueOrVariable(true);
        this.secondVal = RandomGenerator.generateRandomValueOrVariable(true);
        this.comparator = RandomGenerator.generateRandomComparator();
    }
        public override string ToString()
    {
        return $"{firstVal} {comparator} {secondVal}";
    }
}