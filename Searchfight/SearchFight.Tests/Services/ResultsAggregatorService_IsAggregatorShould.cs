using NUnit.Framework;
using Searchfight.Services;
using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System;
using System.Collections.Generic;

namespace SearchFight.Tests.Services
{
    [TestFixture]
    public class ResultsAggregatorService_IsAggregatorShould
    {
        private IResultsAggregatorService _resultsAggregatorService;

        [SetUp]
        public void SetUp()
        {
            _resultsAggregatorService = new ResultsAggregatorService();
        }

        [Test]
        public void FindSearchEnginesWinners_InputEmpty_ShouldThrowArgumentException()
        {
            var input = new List<SearchResultModel>();

            Assert.Throws<ArgumentException>(() => _resultsAggregatorService.FindSearchEnginesWinners(input));
        }

        [Test]
        public void FindSearchEnginesWinners_Input1Element_ShouldThrowArgumentException()
        {
            var input = new List<SearchResultModel>() { new SearchResultModel() { QueryName = ".net", SearchEngineName = "Google", TotalMatchesCount = 9999999 } };

            Assert.Throws<ArgumentException>(() => _resultsAggregatorService.FindSearchEnginesWinners(input));
        }

        [Test]
        public void FindSearchEnginesTotalWinner_InputEmpty_ShouldThrowArgumentException()
        {
            var input = new List<SearchResultModel>();

            Assert.Throws<ArgumentException>(() => _resultsAggregatorService.FindSearchEnginesTotalWinner(input));
        }

        [Test]
        public void FindSearchEnginesTotalWinner_Input1Element_ShouldThrowArgumentException()
        {
            var input = new List<SearchResultModel>() { new SearchResultModel() { QueryName = ".net", SearchEngineName = "Google", TotalMatchesCount = 9999999 } };

            Assert.Throws<ArgumentException>(() => _resultsAggregatorService.FindSearchEnginesTotalWinner(input));
        }

        [Test]
        public void FindSearchEnginesWinners_InputIsOk_ShouldReturnOkResults()
        {
            var input = SeedData();

            var results = _resultsAggregatorService.FindSearchEnginesWinners(input);

            foreach (var result in results)
            {
                Assert.IsTrue(result.QueryName == "java");
            }
        }

        [Test]
        public void FindSearchEnginesTotalWinner_InputIsOk_ShouldReturnOkResults()
        {
            var input = SeedData();

            var result = _resultsAggregatorService.FindSearchEnginesTotalWinner(input);

            Assert.That(result.QueryName == "java" && result.SearchEngineName == "Bing");
        }

        private IList<SearchResultModel> SeedData()
        {
            return new List<SearchResultModel>()
            {
                new SearchResultModel() {
                    QueryName = ".net",
                    SearchEngineName = "Google",
                    TotalMatchesCount = 5000000
                },
                new SearchResultModel() {
                    QueryName = "java",
                    SearchEngineName = "Google",
                    TotalMatchesCount = 6000000
                },
                new SearchResultModel() {
                    QueryName = ".net",
                    SearchEngineName = "Bing",
                    TotalMatchesCount = 4000000
                },
                new SearchResultModel() {
                    QueryName = "java",
                    SearchEngineName = "Bing",
                    TotalMatchesCount = 9000000
                },
            };
        }
    }
}
