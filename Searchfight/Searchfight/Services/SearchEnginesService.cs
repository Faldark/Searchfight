using Searchfight.SearchEngines;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public class SearchEnginesService : ISearchEnginesService
    {
        private readonly IBingSearchEngine _bingSearchEngine;
        private readonly IGoogleSearchEngine _googleSearchEngine;

        public SearchEnginesService()
        {
            _bingSearchEngine = new BingSearchEngine();
            _googleSearchEngine = new GoogleSearchEngine();
        }

        public SearchEnginesService(IBingSearchEngine bingSearchEngine, IGoogleSearchEngine googleSearchEngine)
        {
            _bingSearchEngine = bingSearchEngine;
            _googleSearchEngine = googleSearchEngine;
        }

        public async Task<List<SearchResultModel>> GetSearchResultsAsync(IEnumerable<string> queries)
        {
            if (queries.Count() < 2)
            {
                throw new ArgumentNullException("The input query is not correct, please execute again with a 2 or more search variables");
            }

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
