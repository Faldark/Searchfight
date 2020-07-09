using Microsoft.Extensions.DependencyInjection;
using Searchfight.Configure;
using Searchfight.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Searchfight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = ContainerConfiguration.GetServices();
            await serviceProvider.GetService<IExecutionFlowService>().Run(args.ToList());
        }
    }
}