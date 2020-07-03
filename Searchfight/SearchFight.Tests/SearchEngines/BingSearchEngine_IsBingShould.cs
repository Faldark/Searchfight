using NUnit.Framework;
using Searchfight.SearchEngines;
using Searchfight.SearchEngines.Interfaces;
using System;
using System.Threading.Tasks;

namespace SearchFight.Tests.SearchEngines
{
    [TestFixture]
    public class BingSearchEngine_IsBingShould
    {
        private IBingSearchEngine _bingSearchEngine;

        [SetUp]
        public void SetUp()
        {
            _bingSearchEngine = new BingSearchEngine();
        }

        [Test]
        public void GetSearchTotalCountAsync_InputQueryIsEmpty_ThrowException()
        {
            var input = string.Empty;

            Assert.ThrowsAsync<ArgumentNullException>(() => _bingSearchEngine.GetSearchTotalCountAsync(input));
        }

        [Test]
        public async Task GetSearchTotalCountAsync_InputQueryIsOk_ReturnsResult()
        {
            var input = "java script";

            var result = await _bingSearchEngine.GetSearchTotalCountAsync(input);

            Assert.Greater(result, 0);
        }
    }
}
