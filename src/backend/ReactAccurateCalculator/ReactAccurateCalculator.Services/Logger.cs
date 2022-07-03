using ReactAccurateCalculator.Interfaces;

namespace ReactAccurateCalculator.Services
{
    public class Logger : ILogger
    {
        public Task Log(string context, string message)
        {
            return Task.Run(() => Console.WriteLine($"({DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fffZ")}) [{context}]: {message}"));
        }
    }
}
