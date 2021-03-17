using System.Collections.Generic;

namespace Searchers.Domain.Services
{
    public interface ISearchDomainService
    {
        public IEnumerable<SearchDomainModel> ProcessWinners(IEnumerable<SearchDomainModel> searchs);
    }
}
