using Microsoft.Extensions.Options;
using MovieViewerTest.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public abstract class BaseAPIService
    {
        protected APISettings apiSettings { get; }
        protected string API_KEY;
        protected string BASE_URL;

        public BaseAPIService(IOptions<APISettings> APISettings)
        {
            apiSettings = APISettings.Value;
        }

        public async Task<string> GetElementByQueryUsingAPIKeyAsync(string queryDesignator, string query)
        {
            string _elementJSON;
            string url = BASE_URL + $"?{queryDesignator}={query}&apikey={API_KEY}";

            using (HttpClient client = new HttpClient())
            {
                _elementJSON = await client.GetStringAsync(url);
            }

            return _elementJSON;
        }
    }

}
