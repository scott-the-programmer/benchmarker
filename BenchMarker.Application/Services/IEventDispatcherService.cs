using BenchMarker.Application.Events;

namespace BenchMarker.Application.Services
{
    public interface IEventDispatcherService
    {
        public void DispatchEvent<T>(T command) where T : IEvent;
    }
}