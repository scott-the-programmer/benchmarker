namespace BenchMarker.Application.Events
{
    public class DockerBuildEvent : IEvent
    {
        public string Dockerfile { get; set; }
    }
}