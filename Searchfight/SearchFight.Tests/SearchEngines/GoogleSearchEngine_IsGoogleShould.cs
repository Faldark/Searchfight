using NUnit.Framework;
using Searchfight.SearchEngines;
using Searchfight.SearchEngines.Interfaces;
using System;
using System.Threading.Tasks;

namespace SearchFight.Tests.SearchEngines
{
    [TestFixture]
    public class GoogleSearchEngine_IsGoogleShould
    {
        private IGoogleSearchEngine _googleSearchEngine;

        [SetUp]
        public void SetUp()
        {
            _googleSearchEngine = new GoogleSearchEngine();
        }

        [Test]
        public void GetSearchTotalCountAsync_InputQueryIsEmpty_ThrowException()
        {
            var input = string.Empty;

            Assert.ThrowsAsync<ArgumentNullException>(() => _googleSearchEngine.GetSearchTotalCountAsync(input));
        }

        [Test]
        public async Task GetSearchTotalCountAsync_InputQueryIsOk_ReturnsResult()
        {
            var input = "java script";

            var result = await _googleSearchEngine.GetSearchTotalCountAsync(input);

            Assert.Greater(result, 0);
        }
    }
}
