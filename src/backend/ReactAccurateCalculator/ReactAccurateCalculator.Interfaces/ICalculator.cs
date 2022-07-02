namespace ReactAccurateCalculator.Interfaces
{
    public interface ICalculator
    {
        public Task<decimal> Calculate(string equation);
    }
}