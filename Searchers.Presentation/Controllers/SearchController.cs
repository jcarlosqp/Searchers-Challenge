using Searchers.Application.Queries;
using Searchers.Presentation.Adapters;
using Searchers.Presentation.Exceptions;
using Searchers.Presentation.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchers.Presentation.Controllers
{
    class SearchController: ISearchController
    {
        private ISearchQuery _searchService;
        private ISearchView _view;
        const string _YES = "y";

        public SearchController(ISearchQuery searchService, ISearchView view)
        {
            this._searchService = searchService;
            this._view = view;
        }

        public async Task Run()
        {
            string _continue = _YES;

            while (_continue == _YES)
            {
                var args = await Load();
                _continue = await Search(args);
   
            }
        }

        public async Task<IEnumerable<string>> Load()
        {
            return await Task.Run(() => _view.Load());
        }

        public async Task<string> Search(IEnumerable<string> args)
        {
            string response = "";
            if (this.ValidateArgs(args.ToArray()))
            {
                var searchResults = await _searchService.Execute(args);
                var model = ResultsAdapter.GetSearchResultsModel(searchResults);
                response = _view.ShowResults(model);
            }
            return response;
        }

        private bool ValidateArgs(ICollection<string> args)
        {
            if (args == null || args.Count == 0)
            {
                throw new SearchException("You should write some keywords to search.");
            }
            
            if (args.Count < 2) 
            {
                throw new SearchException("Provide at least two keywords to do the comparation.");
            }

            foreach (var arg in args)
            {
                if(string.IsNullOrEmpty(arg))
                    throw new SearchException("Some keyword doesn't have a valor. Verify.");
            }
            return true;
        }
    }
}
