using Searchers.Application.Models;
using Searchers.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Searchers.Presentation.Builders
{
    public class ResultsBuilder
    {
        private readonly StringBuilder _sb;
        private readonly SearchResultsModel _model;
        public ResultsBuilder(SearchResultsModel model)
        {
            _sb = new StringBuilder();
            _model = model;
        }

        public StringBuilder Generate()
        {
            AddTitle();
            AddResults();
            AddTotalWinner();
            return _sb;
        }
        public void AddTitle()
        {
            _sb.AppendLine();
            _sb.AppendLine(_model.Title);
            _sb.AppendLine();
        }
        public void AddResults()
        {
            var dictionary = new Dictionary<string, StringBuilder>();
            StringBuilder sbRow;
            var sbWinnerBySearcher = new StringBuilder();

            foreach (var searchers in _model.Results)
            {
                foreach (var result in searchers.Results)
                {
                    if (!dictionary.TryGetValue(result.keyword, out sbRow)) 
                        sbRow = new StringBuilder();

                    dictionary[result.keyword] = sbRow.Append($"\t{searchers.Name}: {result.result}");
                }
                sbWinnerBySearcher.AppendLine($"{searchers.Name} Winner: {searchers.Winner}");
            }

            foreach (var e in dictionary)
            {
                _sb.Append($"{e.Key}: ");
                _sb.Append(e.Value);
                _sb.AppendLine();
            }
            _sb.AppendLine();
            _sb.AppendLine("----------------------------------------------------");
            _sb.Append(sbWinnerBySearcher);            
        }

        public void AddTotalWinner()
        {
            _sb.AppendLine();
            _sb.AppendLine($"Total Winner: {_model.TotalWinner}");
        }
    }
}
