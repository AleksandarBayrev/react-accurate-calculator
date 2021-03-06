using ReactAccurateCalculator.Interfaces;

namespace ReactAccurateCalculator.Services
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string FilePath { get; init; }
        public bool RequireHTTPS { get; init; }
    }
}
