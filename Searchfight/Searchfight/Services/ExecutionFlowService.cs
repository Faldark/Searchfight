using Searchfight.Services.Interfaces;
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
            var searchResults = await _searchEnginesService.GetSearchResultsAsync(input);

            var searchEnginesWinnersList = _resultsAggregatorService.FindSearchEnginesWinners(searchResults).ToList();
            var searchEnginestotalWinner = _resultsAggregatorService.FindSearchEnginesTotalWinner(searchResults);

            _resultOutputService.OutputSearchResults(searchResults);
            _resultOutputService.OutputWinners(searchEnginesWinnersList);
            _resultOutputService.OutputTotalWinner(searchEnginestotalWinner);
        }
    }
}
