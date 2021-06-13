using BenchMarker.CLI.Commands;
using CommandLine;

namespace BenchMarker.Application.Commands
{
    [Verb("docker")]
    public class RunDockerCommand : ICommand
    { 
        [Option('d', "docker-file", Required = true, HelpText = "Dockerfile to benchmark")]     
        public string DockerFile { get; set; }
    }
}