namespace ReactAccurateCalculator.Interfaces
{
    public interface IApplicationConfiguration
    {
        public string FilePath { get; init; }
        public bool RequireHTTPS { get; init; }
    }
}
