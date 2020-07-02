using Newtonsoft.Json;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.SearchEngines.Models.Google;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight.SearchEngines
{
    class GoogleSearchEngine : IGoogleSearchEngine
    {
        private HttpClient _httpClient;

        public string Name => "Google";

        /// <summary>
        /// Todo: May add ctor to inject <see cref="HttpClient"/>
        /// </summary>
        public GoogleSearchEngine()
        {
            _httpClient = new HttpClient();
        }

        public async Task<long> GetSearchTotalCountAsync(string input)
        {
            var result = await this._httpClient.GetAsync(GoogleRequestModel.GetUrl(input));
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<GoogleResponseModel>(await result.Content.ReadAsStringAsync());
                return response.SearchInformation.TotalResults;
            }
            throw new Exception(result.ReasonPhrase);
        }
    }
}
