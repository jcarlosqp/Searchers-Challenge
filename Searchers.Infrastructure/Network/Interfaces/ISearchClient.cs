using Searchers.Infrastructure.Models;
using System.Threading.Tasks;

namespace Searchers.Infrastructure.Network.SearchEngines.Interfaces
{
    public interface ISearchClient
    {
        string Name { get; }
        Task<SearchResultModel> SearchAsync(string searchText);
    }
}
