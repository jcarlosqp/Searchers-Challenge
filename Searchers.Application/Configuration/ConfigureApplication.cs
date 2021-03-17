using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Searchers.Application.Queries;
using Searchers.Domain.Interfaces;
using Searchers.Domain.Services;
using Searchers.Infrastructure.Proxy;

namespace Searchers.Application.Configuration
{
    public class ConfigureApplication
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISearchQuery, SearchQuery>();
            services.AddSingleton<ISearchProxy, SearchProxy>();
            services.AddSingleton<ISearchDomainService, SearchDomainService>();
            services.AddMemoryCache(m => new MemoryCacheOptions()
            {
                SizeLimit = 1024
            });
        }
    }
}
