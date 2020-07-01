using Searchfight.Services.Models;
using System.Collections.Generic;

namespace Searchfight.Services.Interfaces
{
    public interface IResultsAggregatorService
    {
        public IEnumerable<SearchEngineWinner> FindSearchEnginesWinners(IList<SearchResultModel> results);
        public SearchEngineWinner FindSearchEnginesTotalWinner(IList<SearchResultModel> results);
    }
}
