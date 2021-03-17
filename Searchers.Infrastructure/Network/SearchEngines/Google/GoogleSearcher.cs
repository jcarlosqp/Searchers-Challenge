using Microsoft.Extensions.Configuration;
using Searchers.Infrastructure.Common;
using Searchers.Infrastructure.Models;
using Searchers.Infrastructure.Network.SearchEngines.Interfaces;
using System;
using System.Threading.Tasks;

namespace Searchers.Infrastructure.Network.SearchEngines.Google
{
    public class GoogleSearcher : ISearchClient
    {
        public string Name { get; private set; }

        private readonly string _urlBase;

        public GoogleSearcher(IConfiguration config)
        {
            Name = config["GoogleName"].ToString();

            string queryParams = $"&key={config["GoogleApiKey"]}&cx={config["GoogleApiEngine"]}&q=";
            _urlBase = config["GoogleApiUrl"].ToString() + queryParams;
        }


        public async Task<SearchResultModel> SearchAsync(string searchText)
        {
            var Url = new Uri(_urlBase + searchText.Replace(" ", "+"));

            var searchResult = await WebClientWrapper.GetAsync<GoogleSearchResult>(Url);

            return new SearchResultModel()
            {
                Name = searchText,
                Results = Convert.ToInt64(searchResult.searchInformation.totalResults),
                Searcher = this.Name
            };
        }
    }
}
