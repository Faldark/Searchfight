using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Searchfight.Services.Models
{
    public class SearchEngineWinner
    {
        [Required]
        public string SearchEngineName { get; set; }
        [Required]
        public string QueryName { get; set; }
    }
}
