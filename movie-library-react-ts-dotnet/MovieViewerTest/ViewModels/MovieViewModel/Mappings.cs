using MovieViewerTest.JsonDeserializedModels;
using MovieViewerTest.Models;

namespace MovieViewerTest.ViewModels.MovieViewModel
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Search, MovieBaseViewModel>();

            CreateMap<MovieDesirializedModel, MovieViewModel>();

            CreateMap<RatingDesirialized, RaitingViewModel>();

            CreateMap<RatingDesirialized, Rating>();

            CreateMap<MovieDesirializedModel, MovieFoundByIMDbID>();

            CreateMap<Search, MovieFoundByTitle>();

            CreateMap<Root, MovieSearchedByTitleResult>()
                .ForMember(d => d.MoviesFoundByTitle, o => o.MapFrom(s => s.Search));
        }
    }
}
