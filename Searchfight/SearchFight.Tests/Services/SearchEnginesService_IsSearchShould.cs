using NUnit.Framework;
using Searchfight.Services;
using Searchfight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.Tests.Services
{
    [TestFixture]
    public class SearchEnginesService_IsSearchShould
    {
        ISearchEnginesService _searchEnginesService;

        [SetUp]
        public void SetUp()
        {
            _searchEnginesService = new SearchEnginesService();
        }

        [Test]
        public void GetSearchResultsAsync_InputQueryIsEmpty_ThrowException()
        {
            var input = new List<string>();

            Assert.ThrowsAsync<ArgumentNullException>(() => _searchEnginesService.GetSearchResultsAsync(input));
        }

        [Test]
        public void GetSearchResultsAsync_InputQuery1Element_ThrowException()
        {
            var input = new List<string>() {".net"};

            Assert.ThrowsAsync<ArgumentNullException>(() => _searchEnginesService.GetSearchResultsAsync(input));
        }

        [Test]
        public async Task GetSearchResultsAsync_InputIsOk_ReturnsResults()
        {
            var input = new List<string>() { ".net", "java" };

            var results = await _searchEnginesService.GetSearchResultsAsync(input);

            foreach (var result in results)
            {
                Assert.That(result.TotalMatchesCount > 0);
                Assert.That(result.QueryName != string.Empty);
                Assert.That(result.SearchEngineName != string.Empty);
            }
        }
    }
}
