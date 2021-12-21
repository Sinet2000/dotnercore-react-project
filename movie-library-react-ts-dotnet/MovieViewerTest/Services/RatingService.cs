using Models;
using MovieViewerTest.Models;
using Services;

namespace MovieViewerTest.Services
{
    public class RatingService : BaseService<Rating>, IRatingService
    {
        public RatingService(IDataContext dataContext) : base(dataContext)
        {
        }
    }

    public interface IRatingService : IBaseService<Rating>
    {

    }
}

