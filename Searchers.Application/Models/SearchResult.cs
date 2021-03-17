using System.Collections.Generic;

namespace Searchers.Application.Models
{
    public class SearchResult
    {
        public string Name { get; set; }
        public IEnumerable<(string keyword, long result)> Results { get; set; }
        public string Winner { get; set; }
    }
}
