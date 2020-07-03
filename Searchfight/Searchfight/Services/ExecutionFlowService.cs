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
        private readonly IResultsOutputService _resultsOutputService;
        public ExecutionFlowService(IResultsAggregatorService resultsAggregatorService, ISearchEnginesService searchEnginesService, IResultsOutputService resultsOutputService)
        {
            _resultsAggregatorService = resultsAggregatorService;
            _searchEnginesService = searchEnginesService;
            _resultsOutputService = resultsOutputService;
        }

        public async Task Run(IEnumerable<string> input)
        {
            if (input.Count() < 2)
            {
                throw new ArgumentException("The input query is not correct, please execute again with a 2 or more search variables");
            }

            Console.WriteLine("Execution in process...");

            var searchResults = await _searchEnginesService.GetSearchResultsAsync(input);

            var searchEnginesWinnersList = _resultsAggregatorService.FindSearchEnginesWinners(searchResults).ToList();
            var searchEnginesTotalWinner = _resultsAggregatorService.FindSearchEnginesTotalWinner(searchResults);

            _resultsOutputService.OutputSearchResults(searchResults);
            _resultsOutputService.OutputWinners(searchEnginesWinnersList);
            _resultsOutputService.OutputTotalWinner(searchEnginesTotalWinner);

            Console.WriteLine("Execution has been completed");
        }
    }
}
