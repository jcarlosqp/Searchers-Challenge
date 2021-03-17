using System;
using System.Collections.Generic;
using System.Text;

namespace Searchers.Presentation.Models
{
    public class ResultsModel
    {
        public string Key { get; set; }
        public IEnumerable<ResultModel> Results { get; set; }
    }
}
