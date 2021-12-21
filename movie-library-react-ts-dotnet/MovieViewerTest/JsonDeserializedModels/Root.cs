using System.Collections.Generic;

namespace MovieViewerTest.JsonDeserializedModels
{
    public class Root
    {
        public List<Search> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
