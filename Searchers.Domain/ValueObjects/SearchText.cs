using System;

namespace Searchers.Domain.ValueObjects
{
    public struct SearchText: IComparable<SearchText>
    {
        public readonly string Name;
        public readonly long Results;
        public SearchText(string name, long results)
        {
            Name = name;
            Results = results;
        }

        public int CompareTo(SearchText other)
        {
            return Results.CompareTo(other.Results);
        }
    }

}
