using System.Threading.Tasks;

namespace Searchfight.SearchEngines.Interfaces
{
    public interface ISearchEngine
    {
        public Task<long> GetSearchTotalCountAsync(string input);
        public string Name { get; }
    }
}
