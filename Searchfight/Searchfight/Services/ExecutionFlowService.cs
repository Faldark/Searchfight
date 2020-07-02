using Searchfight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public class ExecutionFlowService : IExecutionFlowService
    {
        private readonly IResultsAggregatorService _resultsAggregatorService;
        private readonly ISearchEnginesService _searchEnginesService;
        private readonly IResultOutputService _resultOutputService;
        public ExecutionFlowService(IResultsAggregatorService resultsAggregatorService, ISearchEnginesService searchEnginesService, IResultOutputService resultOutputService)
        {
            _resultsAggregatorService = resultsAggregatorService;
            _searchEnginesService = searchEnginesService;
            _resultOutputService = resultOutputService;
        }

        public async Task Run(IEnumerable<string> input)
        {
            if (input.Count() < 2)
            {
                Console.WriteLine("The input query is not correct, please execute again with a 2 or more search variables");
                return;
            }

            Console.WriteLine("Execution in process...");

            var searchResults = await _searchEnginesService.GetSearchResultsAsync(input);

            var searchEnginesWinnersList = _resultsAggregatorService.FindSearchEnginesWinners(searchResults).ToList();
            var searchEnginesTotalWinner = _resultsAggregatorService.FindSearchEnginesTotalWinner(searchResults);

            _resultOutputService.OutputSearchResults(searchResults);
            _resultOutputService.OutputWinners(searchEnginesWinnersList);
            _resultOutputService.OutputTotalWinner(searchEnginesTotalWinner);

            Console.WriteLine("Execution has been completed");
        }
    }
}
