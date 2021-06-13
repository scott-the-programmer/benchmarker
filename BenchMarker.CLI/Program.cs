using System;
using System.CommandLine.Invocation;
using System.Linq;
using System.Reflection;
using Autofac;
using AutofacSerilogIntegration;
using BenchMarker.Application.CommandHandlers;
using BenchMarker.Application.Commands;
using BenchMarker.Application.Services;
using BenchMarker.CLI.Commands;
using BenchMarker.CLI.Exceptions;
using CommandLine;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace BenchMarker.CLI
{
    static class Program
    {
        private static IContainer _container;
        private static string CommandAssembly = "BenchMarker.Application";

        public static void Main(string[] args)
        {
            var types = LoadRunCommands();

            InitAutoFacContainer();
            Parser.Default.ParseArguments(args, types)
                .WithParsed(Run);

            Console.ReadLine();
        }

        private static void InitAutoFacContainer()
        {
            var builder = new ContainerBuilder();
            var commandHandlerAssembly = Assembly.Load(CommandAssembly);

            ConfigureLogger(builder);
            builder.RegisterType<CommandDispatcherService>().As<ICommandDispatcherService>();
            builder.RegisterAssemblyTypes(commandHandlerAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>));
            _container = builder.Build();
        }

        private static void ConfigureLogger(ContainerBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {Message} ({SourceContext:l}){NewLine}{Exception}")
                .CreateLogger();

            builder.RegisterLogger(autowireProperties: true);
            builder.RegisterLogger(Log.Logger);
        }

        private static Type[] LoadRunCommands()
        {
            var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var commandAssemblies = assemblies.First(a => a.Name == CommandAssembly);

            var assembly = Assembly.Load(commandAssemblies);
            var allCommandTypes = assembly.GetTypes()
                .Where(t =>
                    t.GetCustomAttribute<VerbAttribute>() != null
                );

            return allCommandTypes.ToArray();
        }

        private static void Run(object command)
        {
            
            switch (command)
            {
                case RunDockerCommand runDockerCommand:
                    _container.Resolve<ICommandDispatcherService>()
                        .DispatchCommand(runDockerCommand);
                    break;
                case RunKubernetesCommand runKubernetesCommand: 
                    _container.Resolve<ICommandDispatcherService>()
                        .DispatchCommand(runKubernetesCommand);
                    break;
                default:
                    throw new BenchMarkerCommandLineArgException($"invalid command type {command.GetType()}");
            }

            ;
        }
    }
}