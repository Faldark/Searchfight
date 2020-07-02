using Microsoft.Extensions.DependencyInjection;
using Searchfight.Configure;
using Searchfight.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Searchfight
{
    class Program
    {
        static async Task Main(string[] args)
        {


            var serviceProvider = ContainerConfiguration.Configure();
            var test = new string[] { "java", ".net" };
            //await serviceProvider.GetService<IExecutionFlowService>().Run(args.ToList());
            await serviceProvider.GetService<IExecutionFlowService>().Run(test);


            Console.WriteLine("Hello World!");


        }
    }
}