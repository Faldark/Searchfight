using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight.Services
{
    public class ResultsAggregatorService : IResultsAggregatorService
    {
        public IEnumerable<SearchEngineWinner> FindSearchEnginesWinners(IList<SearchResultModel> results)
        {
            if (results.Count < 2)
            {
                throw new ArgumentException("Something went wrong with search query results, please try again later");
            }
            return results.GroupBy(s => s.SearchEngineName, (searchEngineName, totalMatchesCounts) => new SearchEngineWinner
            {
                SearchEngineName = searchEngineName,
                QueryName = totalMatchesCounts.OrderByDescending(x => x.TotalMatchesCount).First().QueryName
            });
        }

        public SearchEngineWinner FindSearchEnginesTotalWinner(IList<SearchResultModel> results)
        {
            if (results.Count < 2)
            {
                throw new ArgumentException("Something went wrong with search query results, please try again later");
            }
            var result = results.OrderByDescending(x => x.TotalMatchesCount).First();

            return new SearchEngineWinner()
            {
                QueryName = result.QueryName,
                SearchEngineName = result.SearchEngineName
            };
        }
    }
}
