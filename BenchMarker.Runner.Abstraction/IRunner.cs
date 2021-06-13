using System;
using System.Threading.Tasks;

namespace BenchMarker.Runner.Abstraction
{
    public interface IRunner
    {
        public Task InvokeProcessAsync(decimal cpu, decimal memory, TimeSpan timeout);
        public IReport RetrieveReport();
    }
}