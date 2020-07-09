using Searchfight.SearchEngines;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchfight.Services
{
    public class SearchEnginesService : ISearchEnginesService
    {
        private readonly IEnumerable<ISearchEngine> _searchEngines;

        public SearchEnginesService()
        {
            _searchEngines = new List<ISearchEngine>() { new BingSearchEngine(), new GoogleSearchEngine() };
        }

        public SearchEnginesService(IEnumerable<ISearchEngine> searchEngines)
        {
            _searchEngines = searchEngines;
        }

        public async Task<List<SearchResultModel>> GetEnginesSearchResultsAsync(IEnumerable<string> queries)
        {
            var results = new List<SearchResultModel>();
            foreach (var query in queries)
            {
                foreach (var searchEngine in _searchEngines)
                {
                    results.Add(await searchEngine.GetSearchTotalCountAsync(query));
                }
            }
            return results;
        }
    }
}
