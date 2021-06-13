using Autofac;
using AutofacSerilogIntegration;
using Serilog;

namespace BenchMarker.CLI.Configure
{
    public static class ContainerBuilderExtension
    {
        /// <summary>
        /// Simple extension method to configure and register a Serilog ILogger
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureLogger(this ContainerBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {Message} ({SourceContext:l}){NewLine}{Exception}")
                .CreateLogger();

            builder.RegisterLogger(autowireProperties: true);
            builder.RegisterLogger(Log.Logger);
        }
    }
}