namespace Searchfight.Services.Models
{
    public class SearchResultModel
    {
        public string SearchEngineName { get; set; }
        public long TotalMatchesCount { get; set; }
        public string QueryName { get; set; }
    }
}
