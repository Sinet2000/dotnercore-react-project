using APIServices;
using Microsoft.Extensions.Options;
using MovieViewerTest.Core.Configuration;
using MovieViewerTest.Helpers;
using MovieViewerTest.JsonDeserializedModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.APIServiceTests
{
    public class MovieAPIServiceTest : TestBase
    {
        [Fact]
        public async Task Should_Return_Movie_By_IMDbID()
        {
            IOptions<APISettings> apiSettings = Options.Create(new APISettings());
            apiSettings.Value.OMDbAPIKey = "b4b05627";
            apiSettings.Value.OMDbURL = "http://www.omdbapi.com/";

            // Arrange
            var testData = testDataModels.GetMovieFoundByIMDbIDBatman();
            // Act
            var service = new MovieAPIService(apiSettings);
            string jsonData = await service.GetElementByQueryUsingAPIKeyAsync(Constants.IMDbIDQueryTag, testData.ImdbID);
            var jsonDeserializedData = JsonConvert.DeserializeObject<MovieDesirializedModel>(jsonData);

            // Assert 
            Assert.NotNull(jsonDeserializedData);
            Assert.Equal(testData.Title, jsonDeserializedData.Title);
            Assert.Equal(testData.Runtime, jsonDeserializedData.Runtime);
            Assert.Equal(testData.Year, jsonDeserializedData.Year);
        }

        [Fact]
        public async Task Should_Return_Movies_By_Title()
        {
            IOptions<APISettings> apiSettings = Options.Create(new APISettings());
            apiSettings.Value.OMDbAPIKey = "b4b05627";
            apiSettings.Value.OMDbURL = "http://www.omdbapi.com/";
            var testQueryTitle = "Superman";
            var responseDataShouldReturnMovieCount = 10;

            // Act
            var service = new MovieAPIService(apiSettings);
            string jsonData = await service.GetElementByQueryUsingAPIKeyAsync(Constants.TitleQueryTag, testQueryTitle);
            var jsonDeserializedData = JsonConvert.DeserializeObject<Root>(jsonData);

            // Assert 
            Assert.NotNull(jsonDeserializedData);
            Assert.Equal(jsonDeserializedData.Search.Count, responseDataShouldReturnMovieCount);
        }
    }
}
