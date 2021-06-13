using System;

namespace BenchMarker.Application.Events
{
    public class DockerEndedEvent : IEvent
    {
        public TimeSpan FinishTime { get; set; } 
    }
}