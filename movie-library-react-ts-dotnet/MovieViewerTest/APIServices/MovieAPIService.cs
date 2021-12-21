using Microsoft.Extensions.Options;
using MovieViewerTest.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices
{
    public class MovieAPIService : BaseAPIService, IMovieAPIService
    {
        public MovieAPIService(IOptions<APISettings> APISettings) : base(APISettings)
        {
            API_KEY = apiSettings.OMDbAPIKey;
            BASE_URL = apiSettings.OMDbURL;
        }
    }

    public interface IMovieAPIService : IBaseAPIService
    {
    }
}
