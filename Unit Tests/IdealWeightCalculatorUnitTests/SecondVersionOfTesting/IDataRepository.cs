namespace SecondVersionOfTesting
{
    public interface IDataRepository
    {
        IEnumerable<WeightCalculator> GetWeightsToCalculate();
    }
}