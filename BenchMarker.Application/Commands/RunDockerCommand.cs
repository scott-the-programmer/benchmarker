using CommandLine;

namespace BenchMarker.Application.Commands
{
    [Verb("docker")]
    public class RunDockerCommand : ICommand
    {
        [Option('d', "docker-file", Required = true, HelpText = "Dockerfile to benchmark")]
        public string DockerFile { get; set; }

        [Option("cpu", Required = false, HelpText = "How much compute power is used")]
        public float Cpu { get; set; }

        [Option("memory", Required = false, HelpText = "How much memory is used")]
        public int Memory { get; set; }
    }
}