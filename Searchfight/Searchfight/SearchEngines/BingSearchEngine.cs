using Newtonsoft.Json;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.SearchEngines.Models.Bing;
using Searchfight.Services.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight.SearchEngines
{
    public class BingSearchEngine : ISearchEngine
    {
        private HttpClient _httpClient;

        public string Name => "Bing";

        public BingSearchEngine() : this(new HttpClient() { BaseAddress = BingRequestModel.Url })
        {
        }

        public BingSearchEngine(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add(BingRequestModel.ApiKeyHeader, BingRequestModel.ApiKey);
        }

        public async Task<SearchResultModel> GetSearchTotalCountAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException($"The {nameof(query)} you provided is null or empty");
            }

            using var result = await _httpClient.GetAsync(new Uri(BingRequestModel.Url + query));
            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Something went wrong with request, statusCode: {result.StatusCode}");
            }

            var response = JsonConvert.DeserializeObject<BingResponseModel>(await result.Content.ReadAsStringAsync());

            return new SearchResultModel()
            {
                SearchEngineName = Name,
                TotalMatchesCount = response.WebPages.TotalEstimatedMatches,
                QueryName = query
            };
        }
    }
}
