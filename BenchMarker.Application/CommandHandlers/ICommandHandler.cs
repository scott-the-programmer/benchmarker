using System.Threading.Tasks;
using BenchMarker.Application.Models;
using BenchMarker.CLI.Commands;

namespace BenchMarker.Application.CommandHandlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<CommandResult> HandleAsync(T command);
    }
}