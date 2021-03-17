using Searchers.Application.Models;
using Searchers.Domain;
using System.Linq;

namespace Searchers.Application.Adapters
{
    internal class SearchModelAdapter
    {
        public static SearchResult GetSearchResult(SearchDomainModel searchModel)
        {
            return new SearchResult()
            {
                Name = searchModel.SearcherName,
                Winner = searchModel.WinnerName,
                Results = searchModel.Terms.Select(e => (keyword: e.Name, result: e.Results))
            };
        }
    }
}
