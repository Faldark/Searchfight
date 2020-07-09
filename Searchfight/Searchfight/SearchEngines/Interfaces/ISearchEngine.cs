using Searchfight.Services.Models;
using System.Threading.Tasks;

namespace Searchfight.SearchEngines.Interfaces
{
    public interface ISearchEngine
    {
        public Task<SearchResultModel> GetSearchTotalCountAsync(string input);
        public string Name { get; }
    }
}
