using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Searchers.Presentation.Controllers
{
    interface ISearchController
    {
        Task Run();
        Task<IEnumerable<string>> Load();
        Task<string> Search(IEnumerable<string> args);
    }
}
