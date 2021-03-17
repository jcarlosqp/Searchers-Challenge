using Microsoft.Extensions.Configuration;
using Searchers.Infrastructure.Models;
using Searchers.Infrastructure.Network.SearchEngines.Bing;
using Searchers.Infrastructure.Network.SearchEngines.Google;
using Searchers.Infrastructure.Network.SearchEngines.Interfaces;
using Searchers.Infrastructure.Network.SearchEngines.Other;
using System.Collections.Generic;

namespace Searchers.Infrastructure.Factories
{
    public class SearcherFactory
    {
        public static IList<ISearchClient> CreateAllSearchers(IConfiguration config)
        {
            return new List<ISearchClient>
            {
                CreateSearcher(SearcherEnum.Google, config),
                CreateSearcher(SearcherEnum.Bing, config)
            };
        }

        public static ISearchClient CreateSearcher(SearcherEnum type, IConfiguration config)
        {
            ISearchClient searcher = null;
            switch (type)
            {
                case SearcherEnum.Google:
                    searcher = new GoogleSearcher(config);
                    break;

                case SearcherEnum.Bing:
                    searcher = new BingSearcher(config);
                    break;

            }
            return searcher;
        }
    }
}
