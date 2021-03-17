using Searchers.Presentation.Models;
using System.Collections.Generic;

namespace Searchers.Presentation.Views
{
    interface ISearchView
    {
        IEnumerable<string> Load();
        string ShowResults(SearchResultsModel model);
    }
}
