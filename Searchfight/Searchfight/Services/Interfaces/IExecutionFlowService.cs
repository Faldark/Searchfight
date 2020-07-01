using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchfight.Services.Interfaces
{
    public interface IExecutionFlowService
    {
        public Task Run(IEnumerable<string> input);
    }
}
