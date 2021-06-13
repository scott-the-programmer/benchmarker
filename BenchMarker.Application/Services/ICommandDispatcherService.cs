using BenchMarker.Application.Commands;

namespace BenchMarker.Application.Services
{
    public interface ICommandDispatcherService
    {
        public void DispatchCommand<T>(T command) where T : ICommand;
    }
}