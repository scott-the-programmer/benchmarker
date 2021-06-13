using CommandLine;

namespace BenchMarker.Application.Commands
{
    [Verb("kubernetes", HelpText = "Uses the kubernetes runtime to perform benchmarks")]
    public class RunKubernetesCommand : ICommand
    {
        [Option('s', "pod-spec", Required = true, HelpText = "Pod spec to benchmark")]     
        public string DockerFile { get; set; }
    }
}