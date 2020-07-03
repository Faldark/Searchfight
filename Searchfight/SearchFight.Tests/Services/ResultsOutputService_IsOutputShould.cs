using NUnit.Framework;
using Searchfight.Services;
using Searchfight.Services.Interfaces;
using Searchfight.Services.Models;
using System;
using System.Collections.Generic;

namespace SearchFight.Tests.Services
{
    [TestFixture]
    public class ResultsOutputService_IsOutputShould
    {
        private IResultsOutputService _resultsOutputService;

        [SetUp]
        public void SetUp()
        {
            _resultsOutputService = new ResultsOutputService();
        }

        [Test]
        public void OutputSearchResults_InputEmptyFields_ShouldThrowArgumentException()
        {
            var input = new List<SearchResultModel>() { new SearchResultModel() {
                QueryName = "java"
            } };

            Assert.Throws<ArgumentException>(() => _resultsOutputService.OutputSearchResults(input));
        }

        [Test]
        public void OutputTotalWinner_InputEmptyFields_ShouldThrowArgumentException()
        {
            var input = new SearchEngineWinner() { QueryName = "java" };

            Assert.Throws<ArgumentException>(() => _resultsOutputService.OutputTotalWinner(input));
        }

        [Test]
        public void OutputWinners_InputEmptyFields_ShouldThrowArgumentException()
        {
            var input = new List<SearchEngineWinner>() { new SearchEngineWinner() {
                QueryName = "java"
            } };

            Assert.Throws<ArgumentException>(() => _resultsOutputService.OutputWinners(input));
        }

        [Test]
        public void OutputSearchResults_InputIsOk_ShouldNotThrowException()
        {
            var input = new List<SearchResultModel>() { new SearchResultModel() {
                QueryName = "java",
                SearchEngineName = "Google",
                TotalMatchesCount = 500000
            } };

            Assert.DoesNotThrow(() => _resultsOutputService.OutputSearchResults(input));
        }

        [Test]
        public void OutputTotalWinner_InputIsOk_ShouldNotThrowException()
        {
            var input = new SearchEngineWinner() { QueryName = "java", SearchEngineName = "Google" };

            Assert.DoesNotThrow(() => _resultsOutputService.OutputTotalWinner(input));
        }

        [Test]
        public void OutputWinners_InputIsOk_ShouldNotThrowException()
        {
            var input = new List<SearchEngineWinner>() { new SearchEngineWinner() {
                QueryName = "java",
                SearchEngineName = "Google"
            } };

            Assert.DoesNotThrow(() => _resultsOutputService.OutputWinners(input));
        }
    }
}
