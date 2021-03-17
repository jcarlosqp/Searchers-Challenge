using Searchers.Domain;
using Searchers.Domain.Services;
using Searchers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Searchers.Tests.Application
{
    public class SearchDomainServiceTests
    {
        private SearchDomainService _searchDomainService;
        private SearchDomainModel _search1Model;
        private SearchDomainModel _search2Model;

        private const string _java = "JAVA";
        private const string _net = ".NET";
        private const string _python = "PYTHON";

        private const string _searcher1 = "Google";
        private const string _searcher2 = "BING";

        public SearchDomainServiceTests()
        {
            this._search1Model = new SearchDomainModel()
            {
                SearcherName = _searcher1,
                Terms = new List<SearchText>()
                {
                    new SearchText(_net, 45000),
                    new SearchText(_java, 62000)
                } 
            };
            this._search2Model = new SearchDomainModel()
            {
                SearcherName = _searcher2,
                Terms = new List<SearchText>()
                {
                    new SearchText(_net, 9999000),
                    new SearchText(_java, 650000)
                }
            };
        }

        [Fact]
        public void TestTotalWinnerOfTwoSearchEngine()
        {
            //Arrange
            _searchDomainService = new SearchDomainService();
            var searchList = new List<SearchDomainModel>() { _search1Model, _search2Model };

            //Act
            var results = _searchDomainService.ProcessWinners(searchList);

            //Assert
            Assert.Equal(_net, results.FirstOrDefault(r => r.SearcherName.ToLower() == "total").WinnerName);
        }

    }
}
