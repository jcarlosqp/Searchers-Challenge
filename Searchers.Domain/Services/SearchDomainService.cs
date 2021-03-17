using Searchers.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Searchers.Domain.Services
{
    public class SearchDomainService : ISearchDomainService
    {
        private const string _TOTAL = "Total";
        public IEnumerable<SearchDomainModel> ProcessWinners(IEnumerable<SearchDomainModel> searchs)
        {
            //Execute Domain Logic by Search engine
            var searchsList = searchs.ToList();
            searchsList.ForEach(s => s.Process());

            //Execute Domain Logic for Total Winner
            var totalModel = GenerateTotalWinner(searchsList);
            searchsList.Add(totalModel);
            return searchsList;
        }

        private SearchDomainModel GenerateTotalWinner(IEnumerable<SearchDomainModel> searchs)
        {
            var totalModel = new SearchDomainModel() { SearcherName = _TOTAL };

            //Process totals by search text
            totalModel.Terms = searchs.SelectMany(s => s.Terms)
                      .GroupBy(g => g.Name, g => g.Results, (key, results) => new SearchText(key, results.Sum()))
                      .ToList();

            //Process total winner
            totalModel.Process();

            return totalModel;
        }
    }
}
