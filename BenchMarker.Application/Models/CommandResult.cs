using System;
using System.Collections.Generic;
using System.Linq;

namespace BenchMarker.Application.Models
{
    public class CommandResult
    {
        public bool Success => !Errors.Any();
        public IList<Exception> Errors { get; set; } = new List<Exception>();
    }
}