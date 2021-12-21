using Microsoft.EntityFrameworkCore;
using Models;
using MovieViewerTest.Models;
using Services;
using System.Linq;
using System.Threading.Tasks;

namespace MovieViewerTest.Services
{
    public class MovieFoundByIMDbIDService : BaseService<MovieFoundByIMDbID>, IMovieFoundByIMDbIDService
    {

        public MovieFoundByIMDbIDService(IDataContext dataContext) : base(dataContext)
        {
        }

        public IQueryable<MovieFoundByIMDbID> GetAllWithRatings()
        {
            return dataContext.MoviesFoundByIMDbID.Include(d => d.Ratings);
        }

        public async Task<MovieFoundByIMDbID> GetMovieAsync(int id)
        {
            return await dataContext.MoviesFoundByIMDbID.FindAsync(id);
        }
    }

    public interface IMovieFoundByIMDbIDService : IBaseService<MovieFoundByIMDbID>
    {
        IQueryable<MovieFoundByIMDbID> GetAllWithRatings();
        Task<MovieFoundByIMDbID> GetMovieAsync(int id);
    }
}
