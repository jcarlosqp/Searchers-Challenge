using Searchers.Application.Models;
using System.Collections.Generic;

namespace Searchers.Presentation.Models
{
    public class SearchResultsModel
    {
        public string Title => "RESULTS:";

        public IEnumerable<SearchResult> Results { get; set; }

        //public ResultsModel Winners { get; set; }

        public string TotalWinner { get; set; }
    }
}
