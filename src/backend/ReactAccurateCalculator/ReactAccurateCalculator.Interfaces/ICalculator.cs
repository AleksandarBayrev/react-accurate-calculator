namespace ReactAccurateCalculator.Interfaces
{
    public interface ICalculator
    {
        public Task<string> Calculate(string equation);
    }
}