using System;
using System.Net.Http;

namespace Searchers.Infrastructure.Common
{
    public sealed class WebClientSingleton
    {
        private static readonly Lazy<HttpClient> _client = new Lazy<HttpClient>();
        public static HttpClient Instance 
        { 
            get { return _client.Value; } 
        }

        private WebClientSingleton()
        {
        }
    }
}
