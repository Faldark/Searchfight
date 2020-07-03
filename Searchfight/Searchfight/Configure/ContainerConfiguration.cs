using Microsoft.Extensions.DependencyInjection;
using Searchfight.SearchEngines;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.Services;
using Searchfight.Services.Interfaces;

namespace Searchfight.Configure
{
    internal static class ContainerConfiguration
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddSingleton<IGoogleSearchEngine, GoogleSearchEngine>()
                .AddSingleton<IBingSearchEngine, BingSearchEngine>()
                .AddSingleton<ISearchEnginesService, SearchEnginesService>()
                .AddSingleton<IResultsAggregatorService, ResultsAggregatorService>()
                .AddSingleton<IExecutionFlowService, ExecutionFlowService>()
                .AddSingleton<IResultsOutputService, ResultsOutputService>()
                .BuildServiceProvider();
        }
    }
}
