using Searchers.Infrastructure.Models;
using Searchers.Infrastructure.Network.SearchEngines.Interfaces;
using System.Threading.Tasks;

namespace Searchers.Infrastructure.Network.SearchEngines.Other
{
    public class OtherSearcher : ISearchClient
    {
        public string Name => "Other";

        public async Task<SearchResultModel> SearchAsync(string searchText)
        {
            throw new System.NotImplementedException();

        }
    }
}
