using Searchfight.Configure;
using System;

namespace Searchfight.SearchEngines.Models.Google
{
    public class GoogleRequestModel
    {
        private static Uri Url => new Uri(SettingsConfiguration.Configuration.GetSection("Google").GetSection("api-address").Value, UriKind.Absolute);
        private static string ApiKey => SettingsConfiguration.Configuration.GetSection("Google").GetSection("api-key").Value;
        private static string ApiCx => SettingsConfiguration.Configuration.GetSection("Google").GetSection("api-cx").Value;

        public static Uri GetUrl(string query)
        {
            var replacedQuery = query.Replace(" ", "+");
            return new Uri(Url, new Uri($"customsearch/v1?key={ApiKey}&cx={ApiCx}&q={replacedQuery}&num=1", UriKind.Relative));
        }
    }
}
