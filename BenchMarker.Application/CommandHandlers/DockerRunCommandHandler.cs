using System.Threading.Tasks;
using BenchMarker.Application.Commands;
using BenchMarker.Application.Events;
using BenchMarker.Application.Models;
using Serilog;

namespace BenchMarker.Application.CommandHandlers
{
    public class DockerRunCommandHandler : CommandHandler<RunDockerCommand>
    {
        private ILogger _logger;

        public DockerRunCommandHandler(ILogger logger)
        {
            _logger = logger;
        }

        protected override Task<CommandResult> HandleAsync(RunDockerCommand command)
        {
            var @event = new DockerBuildEvent()
            {
                Dockerfile = command.DockerFile,
                Cpu = command.Cpu,
                Memory = command.Memory
            };
            
            return Task.FromResult(new CommandResult());
        }
    }
}