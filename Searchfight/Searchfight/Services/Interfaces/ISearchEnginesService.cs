using Searchfight.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchfight.Services.Interfaces
{
    public interface ISearchEnginesService
    {
        public Task<List<SearchResultModel>> GetEnginesSearchResultsAsync(IEnumerable<string> queries);
    }
}
