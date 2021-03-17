using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Searchers.Infrastructure.Common
{
    public static class WebClientExtensions
    {
        public static async Task<T> ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(data) ?
                            default(T) :
                            JsonSerializer.Deserialize<T>(data);
        }
    }
}
