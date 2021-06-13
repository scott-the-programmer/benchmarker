using System.Threading.Tasks;
using BenchMarker.Application.Commands;
using BenchMarker.Application.Models;

namespace BenchMarker.Application.CommandHandlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<CommandResult> HandleAsync(T command);
    }
}