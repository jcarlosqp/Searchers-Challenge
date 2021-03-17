using Searchers.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchers.Application.Queries
{
    public interface ISearchQuery
    {
        public Task<IEnumerable<SearchResult>> Execute(IEnumerable<string> keywords);
    }
}
