using MovieViewerTest.Models;
using MovieViewerTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class MovieFoundByIMDbIDServiceTest : TestBase
    {
        [Fact]
        public async Task List_should_return_list_of_movies_found_by_IMDbID()
        {
            // Arrange
            using var dbContext = GetDataContext();
            dbContext.MoviesFoundByIMDbID.Add(testDataModels.GetMovieFoundByIMDbIDBatman());
            dbContext.MoviesFoundByIMDbID.Add(testDataModels.GetMovieFoundByIMDbIDGuardians());
            await dbContext.SaveChangesAsync();

            // Act
            var service = new MovieFoundByIMDbIDService(dbContext);
            var result = service.GetAll();

            // Assert 
            Assert.NotNull(result);
            Assert.Equal(2, result.ToList().Count);
        }

        [Fact]
        public async Task GetMovie_should_return_model_for_existing_movie()
        {
            var id = 1;
            using var dbContext = GetDataContext();
            dbContext.MoviesFoundByIMDbID.Add(testDataModels.GetMovieFoundByIMDbIDBatman());
            dbContext.MoviesFoundByIMDbID.Add(testDataModels.GetMovieFoundByIMDbIDGuardians());
            await dbContext.SaveChangesAsync();

            var service = new MovieFoundByIMDbIDService(dbContext);
            var result = await service.GetMovieAsync(id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
    }
}
