using Searchers.Application.Models;
using Searchers.Presentation.Builders;
using Searchers.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Searchers.Presentation.Views
{
    public class SearchResultsView: ISearchView
    {
        public IEnumerable<string> Load()
        {
            Console.Clear();
            Console.WriteLine("SEARCH ENGINES");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("INPUT PARAMETERS: ");
            var args = Console.ReadLine();
            
            return args?.Split(" ");
        }

        public string ShowResults(SearchResultsModel model)
        {
            var sb = new ResultsBuilder(model).Generate();
            Console.WriteLine(sb);

            Console.Write("Other search? (y/n): ");
            var response = Console.ReadLine();
            return response;
        }

    }
}
