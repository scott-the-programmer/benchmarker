using System.Threading.Tasks;
using BenchMarker.Application.Commands;
using BenchMarker.Application.Models;
using Serilog;

namespace BenchMarker.Application.CommandHandlers
{
    public class DockerRunCommandHandler : ICommandHandler<RunDockerCommand>
    {
        private ILogger _logger;

        public DockerRunCommandHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task<CommandResult> HandleAsync(RunDockerCommand command)
        {
            _logger.Information("Running RunDockerCommand");
            return Task.FromResult(new CommandResult());
        }
    }
}