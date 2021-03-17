using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Searchers.Application.Configuration;
using Searchers.Presentation.Controllers;
using Searchers.Presentation.Views;
using System;
using System.IO;

namespace Searchers.Presentation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private IServiceProvider _provider;
        private IServiceCollection _serviceCollection;
        public Startup()
        {
            var environment = Environment.GetEnvironmentVariable("APP_ENVIRONMENT");

            _configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environment}.json", optional: true)
                            .AddEnvironmentVariables()
                            .Build();           
        }

        public void ConfigureServices()
        {
            _serviceCollection = new ServiceCollection();

            // add necessary services
            _serviceCollection.AddSingleton<IConfiguration>(_configuration);
            _serviceCollection.AddSingleton<ISearchView, SearchResultsView>();
            _serviceCollection.AddSingleton<ISearchController, SearchController>();
            
            ConfigureApplication.ConfigureServices(_serviceCollection);

            //_provider = _serviceCollection.BuildServiceProvider();
        }

        public IServiceCollection ServiceCollection => _serviceCollection;

        public IConfiguration Configuration => _configuration;
    }
}
