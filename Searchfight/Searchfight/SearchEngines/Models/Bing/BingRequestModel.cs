using Searchfight.Configure;
using System;

namespace Searchfight.SearchEngines.Models.Bing
{
    public class BingRequestModel
    {
        public static Uri Url => new Uri(SettingsConfiguration.Configuration.GetSection("Bing").GetSection("api-address").Value, UriKind.Absolute);
        public static string ApiKey => SettingsConfiguration.Configuration.GetSection("Bing").GetSection("api-key").Value;
        public static string ApiKeyHeader => SettingsConfiguration.Configuration.GetSection("Bing").GetSection("api-key-header").Value;
    }
}
