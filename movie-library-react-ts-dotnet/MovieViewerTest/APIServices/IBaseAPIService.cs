using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IBaseAPIService
    {
        Task<string> GetElementByQueryUsingAPIKeyAsync(string queryDesignator, string query);
    }
}
