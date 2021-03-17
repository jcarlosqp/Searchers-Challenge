using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchers.Domain.Interfaces
{
    public interface ISearchProxy
    {
        Task<IEnumerable<SearchDomainModel>> Search(IEnumerable<string> keywords);
    }
}
