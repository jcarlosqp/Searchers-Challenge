using System;

namespace Searchers.Presentation.Exceptions
{
    public class SearchException: Exception
    {
        public SearchException(string message): base(message)
        {
            //Console.WriteLine($"SearchException: {message}");
            //Log error details here, later.
            //throw new ArgumentException();
        }
    }
}
