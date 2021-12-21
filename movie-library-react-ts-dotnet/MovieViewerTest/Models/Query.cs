using System;

namespace MovieViewerTest.Models
{
    public class Query
    {
        public int Id { get; set; }

        public string QueryValue { get; set; }

        public MovieSearchedByTitleResult MovieSearchedByTitleResult { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
