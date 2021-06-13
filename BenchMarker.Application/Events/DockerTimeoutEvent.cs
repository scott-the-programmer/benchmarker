using System;

namespace BenchMarker.Application.Events
{
    public class DockerTimeoutEvent : IEvent
    {
        public TimeSpan TimeElapsed { get; set; }
    }
}