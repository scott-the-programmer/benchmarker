namespace BenchMarker.Application.Events
{
    public class DockerBuildEvent : IEvent
    {
        public string Dockerfile { get; set; }
        public float Cpu { get; set; }
        public int Memory { get; set; }
    }
}