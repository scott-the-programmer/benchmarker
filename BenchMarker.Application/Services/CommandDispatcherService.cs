using System;
using Autofac;
using BenchMarker.Application.CommandHandlers;
using BenchMarker.Application.Commands;
using Serilog;

namespace BenchMarker.Application.Services
{
    public class CommandDispatcherService : ICommandDispatcherService
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
        public CommandDispatcherService(ILogger logger,
            IComponentContext componentContext)
        {
            _logger = logger;
            _componentContext = componentContext;
        }

        public async void DispatchCommand<T>(T command) where T : ICommand 
        {
            var handler = _componentContext.Resolve<ICommandHandler<T>>();
            var handlerType = handler.GetType();
            try
            {
                _logger.Information($"Running {handlerType}");
                var result = await handler.HandleAsync(command);
                _logger.Information($"Success: {result.Success}");
            }
            catch (Exception e)
            {
                _logger.Error("encountered handler-level exception", e);
            }
        }
    }
}