using System;
using System.Collections.Generic;
using System.Text;

namespace Searchers.Domain.Entities
{
    public sealed class SearchEntity: Entity
    {
        
        public IEnumerable<SearchDomainModel> SearchResults { get; set; }
    }

}
