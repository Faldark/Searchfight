using Searchfight.Services.Models;
using System.Collections.Generic;

namespace Searchfight.Services.Interfaces
{
    public interface IResultsOutputService
    {
        public void OutputSearchResults(IEnumerable<SearchResultModel> input);
        public void OutputWinners(IEnumerable<SearchEngineWinner> winners);
        public void OutputTotalWinner(SearchEngineWinner totalWinner);
    }
}
