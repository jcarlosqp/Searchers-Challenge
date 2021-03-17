using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchers.Infrastructure.Common
{
    public class WebClientWrapper
    {
        public static async Task<TResult> GetAsync<TResult>(Uri url, IEnumerable<(string keyName, string keyValue)> headers = null)
        {
            try
            {
                WebClientSingleton.Instance.DefaultRequestHeaders.Clear();

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        WebClientSingleton.Instance.DefaultRequestHeaders.Add(header.keyName, header.keyValue);
                    }
                }

                TResult result = default;
                
                var response = await WebClientSingleton.Instance.GetAsync(url);
                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    result = await response.ContentAsType<TResult>();
                }
                else {
                    throw new Exception($"Exception with the search engine endpoint. ResponseStatus:{response.StatusCode}");
                }

                //string resultString = await WebClientSingleton.Instance.GetStringAsync(url);
                //TResult result = JsonSerializer.Deserialize<TResult>(resultString);

                return result;
            }
            catch (Exception)
            {
                // log exception
                throw;
            }
        }
    }
}
