using APIServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieViewerTest.Helpers;
using MovieViewerTest.JsonDeserializedModels;
using MovieViewerTest.Models;
using MovieViewerTest.Services;
using MovieViewerTest.ViewModels.MovieViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class MovieController : BaseController
    {
        private readonly IQueryService queryService;
        private readonly IMovieFoundByIMDbIDService movieFoundByIMDbIDService;
        private readonly IMovieFoundByTitleService movieFoundByTitleService;
        private readonly IMovieAPIService movieAPIService;
        private readonly IMapper mapper;

        public MovieController(
            IQueryService queryService,
            IMovieFoundByIMDbIDService movieFoundByIMDbIDService,
            IMovieFoundByTitleService movieFoundByTitleService,
            IMovieAPIService movieAPIService,
            IMapper mapper)
        {
            this.movieAPIService = movieAPIService;
            this.queryService = queryService;
            this.movieFoundByIMDbIDService = movieFoundByIMDbIDService;
            this.movieFoundByTitleService = movieFoundByTitleService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> GetByTitle(string title)
        {
            title.Replace(' ', Constants.MovieQuerySpaceSymbolSubstitute);
            string jsonData = await movieAPIService.GetElementByQueryUsingAPIKeyAsync(Constants.TitleQueryTag, title);
            var jsonDeserializedData = JsonConvert.DeserializeObject<Root>(jsonData);

            int queryId = SaveFindByTitleQueryAndResultsAndGetQueryId(title, jsonDeserializedData);

            var foundMovieByTitleViewModel = new FoundMovieByTitleViewModel(queryId, mapper.Map<List<MovieBaseViewModel>>(jsonDeserializedData.Search));
            return Json(foundMovieByTitleViewModel);
        }


        public async Task<IActionResult> GetByImdbID(string imdbID, int queryId)
        {
            var associatedMovie = movieFoundByTitleService.GetByQueryId(queryId);

            string jsonData = await movieAPIService.GetElementByQueryUsingAPIKeyAsync(Constants.IMDbIDQueryTag, imdbID);
            var jsonDeserializedData = JsonConvert.DeserializeObject<MovieDesirializedModel>(jsonData);

            var result = mapper.Map<MovieFoundByIMDbID>(jsonDeserializedData);

            associatedMovie.MoviesFoundByIMDbID.Add(result);
            movieFoundByTitleService.Update(associatedMovie);

            return Json(mapper.Map<MovieViewModel>(jsonDeserializedData));
        }

        private int SaveFindByTitleQueryAndResultsAndGetQueryId(string query, Root searchRes)
        {
            var queriesByTitle = queryService.GetAllOrderedByCreateDateWithData().ToList();

            for (int elementIndex = 0; elementIndex < queriesByTitle.Count; elementIndex++)
            {
                if (queriesByTitle.Count() >= Constants.MaxSavedMoviesInDatabaseAllowed)
                {
                    queryService.Delete(queriesByTitle[elementIndex]);
                    queriesByTitle.RemoveAt(elementIndex);
                }
            }

            var searchResult = mapper.Map<MovieSearchedByTitleResult>(searchRes);

            var newQuery = new Query();
            newQuery.CreateDate = DateTime.Now;
            newQuery.QueryValue = query;
            newQuery.MovieSearchedByTitleResult = searchResult;

            queryService.Add(newQuery);

            return newQuery.Id;
        }
    }
}
