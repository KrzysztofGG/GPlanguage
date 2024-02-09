public class BooleanNode:Node{

    String firstVal;
    String secodnVal;
    String comparator;
    public BooleanNode(){
        this.firstVal = RandomGenerator.generateRandomVariable();
        this.secodnVal = RandomGenerator.generateRandomVariable();
        this.comparator = RandomGenerator.generateRandomComparator();
    }

    public BooleanNode(String firstVal, String secodnVal, String comparator)
    {
        this.firstVal = firstVal;
        this.secodnVal = secodnVal;
        this.comparator = comparator;
    }
        public override string ToString()
    {
        return $"{firstVal} {comparator} {secodnVal}";
    }
}