using Searchfight.SearchEngines.Interfaces;
using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public class SearchEnginesService : ISearchEnginesService
    {
        private readonly IBingSearchEngine _bingSearchEngine;
        private readonly IGoogleSearchEngine _googleSearchEngine;

        public SearchEnginesService(IBingSearchEngine bingSearchEngine, IGoogleSearchEngine googleSearchEngine)
        {
            _bingSearchEngine = bingSearchEngine;
            _googleSearchEngine = googleSearchEngine;
        }

        public async Task<List<SearchResultModel>> GetSearchResultsAsync(IEnumerable<string> queries)
        {
            var results = new List<SearchResultModel>();
            foreach (var query in queries)
            {
                results.Add(new SearchResultModel()
                {
                    SearchEngineName = _googleSearchEngine.Name,
                    TotalMatchesCount = await _googleSearchEngine.GetSearchTotalCountAsync(query),
                    QueryName = query
                });
                results.Add(new SearchResultModel()
                {
                    SearchEngineName = _bingSearchEngine.Name,
                    TotalMatchesCount = await _bingSearchEngine.GetSearchTotalCountAsync(query),
                    QueryName = query
                });
            }
            return results;
        }
    }
}
