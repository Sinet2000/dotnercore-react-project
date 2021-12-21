using System.Collections.Generic;

namespace MovieViewerTest.Models
{
    public class MovieFoundByTitle : BaseMovieModel
    {

        public int MovieSearchedByTitleResultId { get; set; }
        public MovieSearchedByTitleResult MovieSearchedByTitleResult { get; set; }

        public List<MovieFoundByIMDbID> MoviesFoundByIMDbID { get; set; }
    }
}
