using System;

namespace BenchMarker.CLI.Exceptions
{
    public class BenchMarkerCommandLineArgException : ArgumentException
    {
        /// <summary>
        /// Thrown when bad arguments are provided
        /// </summary>
        /// <param name="message"></param>
        public BenchMarkerCommandLineArgException(string message) : base(message
        )
        {
        }
    }
}