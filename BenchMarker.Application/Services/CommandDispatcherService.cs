using System;
using Autofac;
using BenchMarker.Application.Extensions;
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

        public async void DispatchCommand(object command)
        {
            var handler = _componentContext.GetCommandHandlerFor(command);
            
            try
            {
                _logger.Information($"Running command {command.GetType()}");
                var result = await  handler.HandleAsync(command);
                _logger.Information($"Success: {result.Success}");
            }
            catch (Exception e)
            {
                _logger.Error("encountered handler-level exception", e);
            }
        }
    }
}