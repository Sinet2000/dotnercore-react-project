using Models;

namespace MovieViewerTest.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public string Source { get; set; }

        public string Value { get; set; }

        public int MovieFoundByImDbId { get; set; }
        public MovieFoundByIMDbID MovieFoundByImDb { get; set; }
    }
}
