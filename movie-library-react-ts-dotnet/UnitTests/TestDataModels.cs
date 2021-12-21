using MovieViewerTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public class TestDataModels
    {
        public MovieFoundByIMDbID GetMovieFoundByIMDbIDBatman() 
        {
            return new MovieFoundByIMDbID()
            {
                Title = "Batman Begins",
                Year = "2005",
                Rated = "PG-13",
                Released = "15 Jun 2005",
                Runtime = "140 min",
                Genre = "Action, Adventure",
                Director = "Christopher Nolan",
                Writer = "Bob Kane, David S. Goyer, Christopher Nolan",
                Actors = "Christian Bale, Michael Caine, Ken Watanabe",
                Plot = "After training with his mentor, Batman begins his fight to free crime-ridden Gotham City from corruption.",
                Language = "English, Mandarin",
                Country = "United Kingdom, United States",
                Awards = "Nominated for 1 Oscar. 13 wins & 79 nominations total",
                Poster = "https://m.media-amazon.com/images/M/MV5BOTY4YjI2N2MtYmFlMC00ZjcyLTg3YjEtMDQyM2ZjYzQ5YWFkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",
                Ratings = new List<Rating>()
                    {
                        new Rating()
                        {
                            Source = "Internet Movie Database",
                            Value = "8.2/10"
                        },
                        new Rating()
                        {
                            Source = "Rotten Tomatoes",
                            Value = "84%"
                        },
                        new Rating()
                        {
                            Source = "Metacritic",
                            Value = "70/100"
                        }
                    },
                Metascore = "70",
                imdbRating = "8.2",
                imdbVotes = "1,347,873",
                ImdbID = "tt0372784",
                Type = "movie"
            };
        }

        public MovieFoundByIMDbID GetMovieFoundByIMDbIDGuardians()
        {
            return new MovieFoundByIMDbID
            {
                Title = "Guardians of the Galaxy Vol. 2",
                Year = "2017",
                Rated = "PG-13",
                Released = "05 May 2017",
                Runtime = "136 min",
                Genre = "Action, Adventure, Comedy",
                Director = "James Gunn",
                Writer = "James Gunn, Dan Abnett, Andy Lanning",
                Actors = "Chris Pratt, Zoe Saldana, Dave Bautista",
                Plot = "The Guardians struggle to keep together as a team while dealing with their personal family issues, notably Star-Lord's encounter with his father the ambitious celestial being Ego.",
                Language = "English",
                Country = "United States",
                Awards = "Nominated for 1 Oscar. 15 wins & 58 nominations total",
                Poster = "https://m.media-amazon.com/images/M/MV5BNjM0NTc0NzItM2FlYS00YzEwLWE0YmUtNTA2ZWIzODc2OTgxXkEyXkFqcGdeQXVyNTgwNzIyNzg@._V1_SX300.jpg",
                Ratings = new List<Rating>()
                    {
                        new Rating()
                        {
                            Source = "Internet Movie Database",
                            Value = "7.6/10"
                        },
                        new Rating()
                        {
                            Source = "Rotten Tomatoes",
                            Value = "85%"
                        },
                        new Rating()
                        {
                            Source = "Metacritic",
                            Value = "67/100"
                        }
                    },
                Metascore = "67",
                imdbRating = "7.6",
                imdbVotes = "600,709",
                ImdbID = "tt3896198",
                Type = "movie"
            };
        }
    }
}
