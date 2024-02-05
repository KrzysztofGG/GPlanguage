public class BooleanNode:Node{

    String firstVal;
    String secodnVal;
    String comparator;
    public BooleanNode(){
        this.firstVal = RandomGenerator.generateRandomVariable();
        this.secodnVal = RandomGenerator.generateRandomVariable();
        this.comparator = RandomGenerator.generateRandomComparator();
    }
        public override string ToString()
    {
        return $"{firstVal} {comparator} {secodnVal}";
    }
}