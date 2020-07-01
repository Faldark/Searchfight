using Microsoft.Extensions.DependencyInjection;
using Searchfight.SearchEngines;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.Services;
using Searchfight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchfight
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //     IConfiguration configuration = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json", true, true)
            //.Build();
            //     var playerSection = configuration.GetSection(nameof(Player));


            var serviceProvider = new ServiceCollection()
            .AddSingleton<IGoogleSearchEngine, GoogleSearchEngine>()
            .AddSingleton<IBingSearchEngine, BingSearchEngine>()
            .AddSingleton<ISearchEnginesService, SearchEnginesService>()
            .AddSingleton<IResultsAggregatorService, ResultsAggregatorService>()
            .AddSingleton<IExecutionFlowService, ExecutionFlowService>()
            .AddSingleton<IResultOutputService, ResultOutputService>()
            .BuildServiceProvider();


            await serviceProvider.GetService<IExecutionFlowService>().Run(InputParser(args));

            //var test = serviceProvider.GetService<ISearchEnginesService>();
            //var resultAggregator = serviceProvider.GetService<IResultsAggregatorService>();
            //var result = await test.GetSearchResultsAsync(new List<string> {".net", "Java", "javascript" });

            //var agregation = resultAggregator.FindSearchEnginesWinners(result).ToList();

            //var totalWinner = resultAggregator.FindSearchEnginesTotalWinner(result);



            Console.WriteLine("Hello World!");


        }

        private static IEnumerable<string> InputParser(string[] input)
        {
            return input.ToList();
        }
    }
}
