using Searchers.Domain.Interfaces;
using Searchers.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Searchers.Domain
{
    public abstract class SearchBase : ISearch
    {
        public string SearcherName { get; set; }
        public IEnumerable<SearchText> Terms { get; set; }
        public SearchText Winner { get; private set; }

        public virtual void Process()
        {
            this.Winner = Terms.Max();
        }
    }
}
