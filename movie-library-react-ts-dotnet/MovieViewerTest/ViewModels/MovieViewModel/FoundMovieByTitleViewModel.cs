using System.Collections.Generic;

namespace MovieViewerTest.ViewModels.MovieViewModel
{
    public class FoundMovieByTitleViewModel
    {
        public int QueryId { get; set; }

        public List<MovieBaseViewModel> Movies { get; set; }

        public FoundMovieByTitleViewModel(int queryId, List<MovieBaseViewModel> movies)
        {
            QueryId = queryId;

            Movies = movies;
        }
    }
}
