using ReactAccurateCalculator.Interfaces;
using System.Collections.Concurrent;

namespace ReactAccurateCalculator.Services
{
    public class FileStorage : IFileStorage
    {
        private IDictionary<string, string> fileStorage;

        public FileStorage()
        {
            this.fileStorage = new ConcurrentDictionary<string, string>();
        }
        public Task<string> AddOrUpdateFile(string path, string contents)
        {
            return Task.Run(async () =>
            {
                if (await this.HasFile(path))
                {
                    this.fileStorage[path] = contents;
                }
                else
                {
                    this.fileStorage.Add(path, contents);
                }
                return contents;
            });
        }

        public Task<string> GetFile(string path)
        {
            return Task.FromResult(this.fileStorage[path]);
        }

        public Task<bool> HasFile(string path)
        {
            return Task.FromResult(this.fileStorage.ContainsKey(path));
        }

        public Task DeleteFile(string path)
        {
            return Task.Run(() =>
            {
                this.fileStorage.Remove(path);
            });
        }
    }
}
