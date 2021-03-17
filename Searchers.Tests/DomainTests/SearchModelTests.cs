using Searchers.Domain;
using Searchers.Domain.ValueObjects;
using System.Collections.Generic;
using Xunit;

namespace Searchers.Tests.Domain
{
    public class SearchModelTests
    {
        private SearchDomainModel _searchModel;
        private List<SearchText> _resultsList;
        private const string _java = "java";
        private const string _net = ".net";
        private const string _python = "python";

        public SearchModelTests()
        {
            this._searchModel = new SearchDomainModel();
            this._resultsList = new List<SearchText>()
            {
                new SearchText(_net, 13200000),
                new SearchText(_java, 405000)
            };
        }

        [Fact]
        public void TestWinnerOfTwoSearchTexts()
        {
            //Arrange
            _searchModel.Terms = _resultsList;
            string expectedWinner = _net;
            //Act
            _searchModel.Process();
            var winner = _searchModel.Winner.Name;
            //Assert
            Assert.Equal(expectedWinner, winner);
        }

        [Fact]
        public void TestWinnerOfThreeSearchTexts()
        {
            //Arrange            
            _resultsList.Add(new SearchText(_python, 950000000));
            _searchModel.Terms = _resultsList;
            string expectedWinner = _python;
            //Act
            _searchModel.Process();
            var winner = _searchModel.Winner.Name;
            //Assert
            Assert.Equal(expectedWinner, winner);
        }
    }
}
