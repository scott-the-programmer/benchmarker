using System;

namespace BenchMarker.Application.Events
{
    public class DockerStartedEvent : IEvent
    {
       public TimeSpan StartTime { get; set; } 
       public string DockerfilePath { get; set; }
       public decimal Cpu { get; set; }
       public decimal Memory { get; set; }
    }
}