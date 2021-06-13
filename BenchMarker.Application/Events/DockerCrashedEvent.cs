namespace BenchMarker.Application.Events
{
    public class DockerCrashedEvent : IEvent
    {
       public string Reason { get; set; } 
    }
}