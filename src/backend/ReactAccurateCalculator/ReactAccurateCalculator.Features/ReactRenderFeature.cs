using MediatR;
using ReactAccurateCalculator.Interfaces;
using System.Collections.Concurrent;

namespace ReactAccurateCalculator.Features
{
    public class ReactRenderFeature
    {
        public class ReactRenderQuery : IRequest<string>
        {
            public bool ReloadFile { get; init; }
        }
        public class ReactRenderQueryHandler : IRequestHandler<ReactRenderQuery, string>
        {
            private readonly IApplicationConfiguration applicationConfiguration;
            private IFileStorage fileStorage;

            public ReactRenderQueryHandler(
                IApplicationConfiguration applicationConfiguration,
                IFileStorage fileStorage)
            {
                this.applicationConfiguration = applicationConfiguration;
                this.fileStorage = fileStorage;
            }
            public async Task<string> Handle(ReactRenderQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.ReloadFile || !(await fileStorage.HasFile(applicationConfiguration.FilePath)))
                    {
                        await this.fileStorage.AddOrUpdateFile(applicationConfiguration.FilePath, await File.ReadAllTextAsync(applicationConfiguration.FilePath));
                    }
                    return await this.fileStorage.GetFile(applicationConfiguration.FilePath);
                }
                catch (Exception)
                {
                    return $"File {applicationConfiguration.FilePath} was not found!";
                }
            }
        }
    }
}
