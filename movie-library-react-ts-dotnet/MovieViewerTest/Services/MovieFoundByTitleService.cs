using Microsoft.EntityFrameworkCore;
using Models;
using MovieViewerTest.Models;
using Services;
using System.Linq;

namespace MovieViewerTest.Services
{
    public class MovieFoundByTitleService : BaseService<MovieFoundByTitle>, IMovieFoundByTitleService
    {
        public MovieFoundByTitleService(IDataContext dataContext) : base(dataContext)
        {
        }

        public MovieFoundByTitle GetByQueryId(int queryId)
        {
            return dataContext.MoviesFoundByTitle
                .Include(m => m.MovieSearchedByTitleResult)
                .ThenInclude(ms => ms.Query)
                .Include(m => m.MoviesFoundByIMDbID)
                .FirstOrDefault(ms => ms.MovieSearchedByTitleResult.QueryId == queryId);
        }
    }

    public interface IMovieFoundByTitleService : IBaseService<MovieFoundByTitle>
    {
        MovieFoundByTitle GetByQueryId(int queryId);
    }
}
