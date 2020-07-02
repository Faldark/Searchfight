using System.ComponentModel.DataAnnotations;

namespace Searchfight.Services.Models
{
    public class SearchResultModel
    {
        [Required]
        public string SearchEngineName { get; set; }
        [Required]
        public long TotalMatchesCount { get; set; }
        [Required]
        public string QueryName { get; set; }
    }
}
