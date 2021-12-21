using Microsoft.EntityFrameworkCore;
using Models;
using MovieViewerTest.Models;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace MovieViewerTest.Services
{
    public class QueryService : BaseService<Query>, IQueryService
    {
        public QueryService(IDataContext dataContext) : base(dataContext)
        {
        }

        public IQueryable<Query> GetAllOrderedByCreateDateWithData()
        {
            return dataContext.Queries
                .OrderBy(q => q.CreateDate)
                .Include(q => q.MovieSearchedByTitleResult)
                    .ThenInclude(movie => movie.MoviesFoundByTitle)
                        .ThenInclude(movie => movie.MoviesFoundByIMDbID)
                        .AsQueryable();
        }
    }

    public interface IQueryService : IBaseService<Query>
    {
        IQueryable<Query> GetAllOrderedByCreateDateWithData();
    }
}
