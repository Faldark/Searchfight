using Newtonsoft.Json;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.SearchEngines.Models.Bing;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight.SearchEngines
{
    public class BingSearchEngine : IBingSearchEngine
    {
        private const string api_base_address = "https://api.cognitive.microsoft.com/bing/v7.0/search?q=";
        private const string api_key = "97f280ede9df4eefa9bb0f8d4171a87a";
        private const string api_key_header = "Ocp-Apim-Subscription-Key";

        private HttpClient _httpClient;

        public string Name => "Bing";

        public BingSearchEngine() : this(new HttpClient() { BaseAddress = new Uri(api_base_address) })
        {
        }

        public BingSearchEngine(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.DefaultRequestHeaders.Add(api_key_header, api_key);
        }

        public async Task<long> GetSearchTotalCountAsync(string input)
        {
            //var parameters = (Query : term,
            //    Count : 0);
            var uri = new Uri(this._httpClient.BaseAddress + input);
            var result = await this._httpClient.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<BingResponseModel>(await result.Content.ReadAsStringAsync());
                return response.WebPages.TotalEstimatedMatches;
            }
            throw new Exception(result.ReasonPhrase);
        }
    }
}
