using Microsoft.EntityFrameworkCore;
using Models;
using MovieViewerTest.Models;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace MovieViewerTest.Services
{
    public class MovieSearchedByTitleResultService : BaseService<MovieSearchedByTitleResult>, IMovieSearchedByTitleResultService
    {
        public MovieSearchedByTitleResultService(IDataContext dataContext) : base(dataContext)
        {
        }
    }

    public interface IMovieSearchedByTitleResultService : IBaseService<MovieSearchedByTitleResult>
    {

    }
}
