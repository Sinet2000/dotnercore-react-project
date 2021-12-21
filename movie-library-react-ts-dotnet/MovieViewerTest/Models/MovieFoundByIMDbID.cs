﻿using System.Collections.Generic;

namespace MovieViewerTest.Models
{
    public class MovieFoundByIMDbID : BaseMovieModel
    {
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }

        public int MovieFoundByTitleId { get; set; }
        public MovieFoundByTitle MovieFoundByTitle { get; set; }
    }
}
