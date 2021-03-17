using Searchers.Application.Models;
using Searchers.Presentation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Searchers.Presentation.Adapters
{
    public class ResultsAdapter
    {
        private const string _TOTAL_KEY = "total";
        public static SearchResultsModel GetSearchResultsModel(IEnumerable<SearchResult> searchResults)
        {
            var result = new SearchResultsModel();
            result.Results = searchResults.Where(m => m.Name.ToLower() != _TOTAL_KEY);
            result.TotalWinner = searchResults.FirstOrDefault(m => m.Name.ToLower() == _TOTAL_KEY).Winner;

            return result;
        }
    }
}
