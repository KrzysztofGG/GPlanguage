public class BooleanNode:Node{

    String firstVal;
    String secodnVal;
    String comparator;
    public BooleanNode(){
        this.firstVal = RandomGenerator.generateRandomValueOrVariable();
        this.secodnVal = RandomGenerator.generateRandomValueOrVariable();
        this.comparator = RandomGenerator.generateRandomComparator();
    }
        public override string ToString()
    {
        return $"{firstVal} {comparator} {secodnVal}";
    }
}