using Newtonsoft.Json;
using Searchfight.SearchEngines.Interfaces;
using Searchfight.SearchEngines.Models.Google;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.SearchEngines
{
    class GoogleSearchEngine : IGoogleSearchEngine
    {
        private const string api_cx = "002950162241673005865:ebnaip5z2pq";
        private const string api_key = "AIzaSyBzuhbttW1OatH3IKW6Mzoqc929obSl9mo";
        private const string search_endpoint = "v1";
        private static readonly Uri api_base_uri = new Uri("https://www.googleapis.com/", UriKind.Absolute);
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
            var uri = new Uri(api_base_uri, GetSearchTotalCountApiRelativeUri(input));
            var result = await this._httpClient.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<GoogleResponseModel>(await result.Content.ReadAsStringAsync());
                return response.SearchInformation.TotalResults;
            }
            throw new Exception(result.ReasonPhrase);
        }

        private static Uri GetSearchTotalCountApiRelativeUri(string q)
        {
            //  google likes + symbol instead of space so why would not we?
            q = q.Replace(" ", "+");
            return new Uri($"customsearch/v1?key={api_key}&cx={api_cx}&q={q}&num=1", UriKind.Relative);
        }
    }
}
