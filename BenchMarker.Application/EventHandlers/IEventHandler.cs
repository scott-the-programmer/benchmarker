using System.Threading.Tasks;
using BenchMarker.Application.Events;

namespace BenchMarker.Application.EventHandlers
{
    public interface IEventHandler<T> where T : IEvent
    {
        public Task ApplyAsync(T @event);
    }
}