using Microsoft.Extensions.Configuration;
using Searchers.Domain;
using Searchers.Domain.Interfaces;
using Searchers.Domain.ValueObjects;
using Searchers.Infrastructure.Factories;
using Searchers.Infrastructure.Models;
using Searchers.Infrastructure.Network.SearchEngines.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchers.Infrastructure.Proxy
{
    public class SearchProxy : ISearchProxy
    {
        private readonly IConfiguration _config;
        public SearchProxy(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<SearchDomainModel>> Search(IEnumerable<string> keywords)
        {
            var searchers = SearcherFactory.CreateAllSearchers(_config).ToList();

            //Optimization for Parallel Searchs
            var searchTextList = await ParallelSearch(keywords, searchers);
 
            var results = searchTextList.GroupBy(s => s.Searcher, e => e, 
                            (key, searchs) => new SearchDomainModel() { 
                                SearcherName = key, 
                                Terms = searchs.Select(s => new SearchText(s.Name, s.Results)).ToList() 
                            });


            return results.ToList();
        }

        private async Task<IEnumerable<SearchResultModel>> ParallelSearch(IEnumerable<string> keywords,
            IEnumerable<ISearchClient> searchers)
        {
            var searchTasks = new List<Task<SearchResultModel>>();
            foreach (var searcher in searchers)
            {
                foreach (var key in keywords)
                {
                    searchTasks.Add(searcher.SearchAsync(key));
                }
            }
            
            await Task.WhenAll(searchTasks);

            return searchTasks.Select(s => s.Result);
        }
    }
}
