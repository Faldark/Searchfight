using Microsoft.Extensions.Configuration;

namespace Searchfight.Configure
{
    internal static class SettingsConfiguration
    {
        public static IConfiguration Configuration()
        {
            return new ConfigurationBuilder()
             .AddJsonFile("appsettings.json").Build();
        }
    }
}
