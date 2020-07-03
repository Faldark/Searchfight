using Newtonsoft.Json;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.SearchEngines.Models.Google;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight.SearchEngines
{
    public class GoogleSearchEngine : IGoogleSearchEngine
    {
        private HttpClient _httpClient;

        public string Name => "Google";

        public GoogleSearchEngine() : this(new HttpClient())
        { 
        
        }

        public GoogleSearchEngine(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetSearchTotalCountAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException($"The {nameof(query)} you provided is null or empty");
            }

            using var result = await _httpClient.GetAsync(GoogleRequestModel.GetUrl(query));
            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Something went wrong with request, statusCode: {result.StatusCode}");
            }
            var response = JsonConvert.DeserializeObject<GoogleResponseModel>(await result.Content.ReadAsStringAsync());
            return response.SearchInformation.TotalResults;
        }
    }
}
