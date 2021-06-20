using System;

namespace BenchMarker.Application.Exceptions
{
    public class CommandHandlerNotFoundException : ArgumentException
    {
        public CommandHandlerNotFoundException(string message) : base(message)
        {
        }
    }
}