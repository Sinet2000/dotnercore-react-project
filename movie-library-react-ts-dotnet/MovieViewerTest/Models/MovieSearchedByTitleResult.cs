using System;
using System.Collections.Generic;

namespace MovieViewerTest.Models
{
    public class MovieSearchedByTitleResult
    {
        public int Id { get; set; }
        public List<MovieFoundByTitle> MoviesFoundByTitle { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }

        public int QueryId { get; set; }

        public Query Query { get; set; }
    }
}
