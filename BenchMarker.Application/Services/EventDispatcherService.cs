using System;
using Autofac;
using BenchMarker.Application.CommandHandlers;
using BenchMarker.Application.Commands;
using BenchMarker.Application.EventHandlers;
using BenchMarker.Application.Events;
using Serilog;

namespace BenchMarker.Application.Services
{
    public class EventDispatcherService : IEventDispatcherService
    {
        private readonly ILogger _logger;
        private readonly IComponentContext _componentContext;

        
        /// <summary>
        /// Dispatches commands to command handlers
        /// e.g. where myCommand is of type MyCommand
        /// <code>
        ///     CommandDispatcherService.DispatchCommand(myCommand); //Dispatch command 
        ///         -> invokes
        ///     MyCommandHandler.HandleAsync(myCommand);
        /// </code>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="componentContext"></param>
        public EventDispatcherService(ILogger logger,
            IComponentContext componentContext)
        {
            _logger = logger;
            _componentContext = componentContext;
        }

        public async void DispatchEvent<T>(T @event) where T : IEvent 
        {
            var handler = _componentContext.Resolve<IEventHandler<T>>();
            var handlerType = handler.GetType();
            try
            {
                _logger.Information($"Running {handlerType}");
                await handler.ApplyAsync(@event);
                _logger.Information($"Event handler completed");
            }
            catch (Exception e)
            {
                _logger.Error("encountered handler-leve exception", e);
            }
        }
    }
}