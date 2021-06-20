using System.Threading.Tasks;
using BenchMarker.Application.Commands;
using BenchMarker.Application.Models;

namespace BenchMarker.Application.CommandHandlers
{
    public interface ICommandHandler
    {
        Task<CommandResult> HandleAsync(object command);
    }

    public abstract class CommandHandler<T> : ICommandHandler where T : ICommand
    {
        protected abstract Task<CommandResult> HandleAsync(T command);

        public Task<CommandResult> HandleAsync(object command)
        {
            return HandleAsync((T) command);
        }
    }
}