using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System.Collections.Generic;

namespace Searchfight.Services
{
    public class ResultOutputService : IResultOutputService
    {
        public void OutputSearchResults(IEnumerable<SearchResultModel> input)
        {
            throw new System.NotImplementedException();
        }

        public void OutputTotalWinner(SearchEngineWinner totalWinner)
        {
            throw new System.NotImplementedException();
        }

        public void OutputWinners(IEnumerable<SearchEngineWinner> winners)
        {
            throw new System.NotImplementedException();
        }
    }
}
