using Microsoft.Extensions.Configuration;
using Searchers.Infrastructure.Common;
using Searchers.Infrastructure.Models;
using Searchers.Infrastructure.Network.SearchEngines.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchers.Infrastructure.Network.SearchEngines.Bing
{
    public class BingSearcher : ISearchClient
    {
        public string Name { get; private set; }
        private readonly string _urlBase;
        private readonly List<(string keyName, string keyValue)> _headers;

        public BingSearcher(IConfiguration config)
        {
            Name = config["BingName"].ToString();
            _urlBase = $"{config["BingApiUrl"]}&q=";

            _headers = new List<(string keyName, string keyValue)>();
            _headers.Add((config["BingApiKeyName"], config["BingApiKeyValue"]));
        }


        public async Task<SearchResultModel> SearchAsync(string searchText)
        {
            var Url = new Uri(this._urlBase + searchText.Replace(" ", "+"));

            var searchResult = await WebClientWrapper.GetAsync<BingSearchResult>(Url, this._headers);

            return new SearchResultModel() { 
                Name = searchText,
                Results = searchResult.webPages.totalEstimatedMatches,
                Searcher = this.Name
            };
        }
    }
}
