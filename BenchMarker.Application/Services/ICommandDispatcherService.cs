
namespace BenchMarker.Application.Services
{
    public interface ICommandDispatcherService
    {
        public void DispatchCommand(object command);
    }
}