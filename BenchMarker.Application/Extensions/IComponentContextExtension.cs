using System.Linq;
using Autofac;
using BenchMarker.Application.CommandHandlers;
using BenchMarker.Application.Exceptions;

namespace BenchMarker.Application.Extensions
{
    // ReSharper disable once InconsistentNaming
    // Ignored due to being an interface extension 
    public static class IComponentContextExtension
    {
        /// <summary>
        /// Returns the command handler for the given (object) command
        /// </summary>
        /// <param name="context">IComponentContext</param>
        /// <param name="command">object casted ICommand object</param>
        /// <returns></returns>
        public static ICommandHandler GetCommandHandlerFor(this IComponentContext context, object command)
        {
            //TODO: This should be cached during runtime
            var commandHandlerType = context.ComponentRegistry.Registrations
                .Where(r => typeof(ICommandHandler).IsAssignableFrom(r.Activator.LimitType))
                .Select(r => r.Activator.LimitType)
                .FirstOrDefault(t => t.BaseType?.GenericTypeArguments.Length > 0 &&
                                     t.BaseType.GenericTypeArguments[0] == command.GetType());
            
            if (commandHandlerType == null)
                throw new CommandHandlerNotFoundException($"Could not find handler for type {command}");
            
            return context.Resolve<ICommandHandler>(new NamedParameter("serviceName", commandHandlerType.Name));
        }
    }
}