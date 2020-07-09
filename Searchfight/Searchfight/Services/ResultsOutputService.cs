﻿using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Searchfight.Services
{
    public class ResultsOutputService : IResultsOutputService
    {
        public void OutputSearchResults(IEnumerable<SearchResultModel> searchResults)
        {
            InputListValidation(searchResults);
            var orderedList = searchResults.GroupBy(x => x.QueryName);
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
            InputValidation(totalWinner);
            Console.WriteLine($"Total winner: {totalWinner.QueryName}");
        }

        public void OutputWinners(IEnumerable<SearchEngineWinner> winners)
        {
            InputListValidation(winners);

            var result = new StringBuilder();
            foreach (var winner in winners)
            {
                result.Append($"\n{winner.SearchEngineName} winner: {winner.QueryName}");
            }
            Console.WriteLine(result);
        }

        private void InputValidation(object searchResult)
        {
            var context = new ValidationContext(searchResult, serviceProvider: null, items: null);
            var errorResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(searchResult, context, errorResults))
            {
                throw new ArgumentException($"Search results are corrupted, we got an error: {errorResults.First().ErrorMessage}");
            }
        }

        private void InputListValidation(IEnumerable<object> searchResults)
        {
            foreach (var searchResult in searchResults)
            {
                var context = new ValidationContext(searchResult, serviceProvider: null, items: null);
                var errorResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(searchResult, context, errorResults))
                {
                    throw new ArgumentException($"Search results are corrupted, we got an error: {errorResults.First().ErrorMessage}");
                }
            }
            
        }
    }
}
