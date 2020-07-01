using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Services
{
    public class ResultsAggregatorService : IResultsAggregatorService
    {
        public IEnumerable<SearchEngineWinner> FindSearchEnginesWinners(IList<SearchResultModel> results)
        {
            return results.GroupBy(s => s.SearchEngineName, (searchEngineName, totalMatchesCounts) => new SearchEngineWinner
            {
                SearchEngineName = searchEngineName,
                QueryName = totalMatchesCounts.OrderByDescending(x => x.TotalMatchesCount).First().QueryName
            });
        }

        public SearchEngineWinner FindSearchEnginesTotalWinner(IList<SearchResultModel> results)
        {
            var result = results.OrderByDescending(x => x.TotalMatchesCount).First();

            return new SearchEngineWinner()
            {
                QueryName = result.QueryName,
                SearchEngineName = result.SearchEngineName
            };
        }
    }
}
