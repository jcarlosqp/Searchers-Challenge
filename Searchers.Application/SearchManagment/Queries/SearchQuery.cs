using Microsoft.Extensions.Caching.Memory;
using Searchers.Application.Adapters;
using Searchers.Application.Common;
using Searchers.Application.Models;
using Searchers.Domain.Interfaces;
using Searchers.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchers.Application.Queries
{
    public class SearchQuery : ISearchQuery
    {
        private readonly ISearchProxy _proxy;
        private readonly ISearchDomainService _searchDomainService;
        private readonly IMemoryCache _cache;

        public SearchQuery(ISearchProxy searchRepository, ISearchDomainService searchDomainService, IMemoryCache cache)
        {
            _proxy = searchRepository;
            _searchDomainService = searchDomainService;
            _cache = cache;
        }
        public async Task<IEnumerable<SearchResult>> Execute(IEnumerable<string> keywords)
        {
            IEnumerable<SearchResult> searchResult;
            var key = LocalMemoryCache<IEnumerable<SearchResult>>.GenerateKey(keywords);
            //Get from Local cache or execute the search.
            searchResult = await LocalMemoryCache<IEnumerable<SearchResult>>
                            .GetOrCreateAsync(_cache, key, () => ExecuteSearch(keywords));

            return searchResult;
        }

        private async Task<IEnumerable<SearchResult>> ExecuteSearch(IEnumerable<string> keywords)
        {
            //Process the searchs using the search engines
            var searchs = await _proxy.Search(keywords);

            //Execute Domain Logic
            var results = _searchDomainService.ProcessWinners(searchs);

            IEnumerable<SearchResult> searchResult = results.Select(result => SearchModelAdapter.GetSearchResult(result));

            return searchResult;
        }

    }
}
