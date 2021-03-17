using Searchers.Domain.ValueObjects;
using System.Collections.Generic;

namespace Searchers.Domain
{
    public class SearchDomainModel : SearchBase
    {
        public SearchDomainModel()
        {
            this.Terms = new List<SearchText>();
        }
        public string WinnerName => Winner.Name;

        public long WinnerResults => Winner.Results;
    }
}
