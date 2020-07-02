using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Searchfight.Services
{
    public class ResultsOutputService : IResultOutputService
    {
        public void OutputSearchResults(IEnumerable<SearchResultModel> input)
        {
            var orderedList = input.GroupBy(x => x.QueryName);
            var result = new StringBuilder();
            foreach (var element in orderedList)
            {
                result.Append($"\n{element.Key}:");
                foreach (var record in element)
                {
                    result.Append($" {record.SearchEngineName}: {record.TotalMatchesCount}");
                }
            }
            Console.WriteLine(result);
        }

        public void OutputTotalWinner(SearchEngineWinner totalWinner)
        {
            Console.WriteLine($"Total winner: {totalWinner.QueryName}");
        }

        public void OutputWinners(IEnumerable<SearchEngineWinner> winners)
        {
            var result = new StringBuilder();

            foreach (var winner in winners)
            {
                result.Append($"\n{winner.SearchEngineName} winner: {winner.QueryName}");
            }
            Console.WriteLine(result);
        }
    }
}
