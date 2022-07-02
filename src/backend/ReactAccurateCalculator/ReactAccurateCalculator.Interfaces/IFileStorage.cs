namespace ReactAccurateCalculator.Interfaces
{
    public interface IFileStorage
    {
        public Task<string> GetFile(string path);
        public Task<string> AddOrUpdateFile(string path, string contents);
        public Task DeleteFile(string path);
        public Task<bool> HasFile(string path);
    }
}
