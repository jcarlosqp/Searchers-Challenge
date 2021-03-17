using Microsoft.Extensions.DependencyInjection;
using Searchers.Presentation.Controllers;
using Searchers.Presentation.Exceptions;
using System;
using System.Threading.Tasks;

namespace Searchers.Presentation
{
    class Program
    {
        static async Task Main(string[] args )
        {
            try
            {
                await BuildAndRun();

            }
            catch (SearchException e)
            {
                Console.WriteLine($"Search Exception: Message: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sorry, something bad happened. Message: {e.Message}");
                //Log error
            }
            finally{
                Console.WriteLine("Enter to exit: ");
                Console.ReadLine();
            }
        }

        static async Task BuildAndRun()
        {
            var startup = new Startup();
            startup.ConfigureServices();
            using (var provider = startup.ServiceCollection.BuildServiceProvider())
            {
                var controller = provider.GetRequiredService<ISearchController>();
                await controller.Run();
                
            }
            
        }
    }
}
