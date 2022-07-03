namespace ReactAccurateCalculator.Interfaces
{
    public interface ILogger
    {
        Task Log(string context, string message);
    }
}
