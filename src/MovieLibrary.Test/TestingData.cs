using System;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Test
{
    public static class TestingData
    {

        public static List<Movie> GetSampleMovies()
        {
            var actionCategory = new Category { Id = 1, Name = "Action" };
            var crimeCategory = new Category { Id = 3, Name = "Crime" };
            var sciFiCategory = new Category { Id = 4, Name = "Sci-Fi" };
            var dramaCategory = new Category { Id = 5, Name = "Drama" };
            var thrillerCategory = new Category { Id = 6, Name = "Thriller" };

            var inceptionMovie = new Movie
            {
                Id = 1,
                Title = "Inception",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                Year = 2010,
                ImdbRating = 8.8m,
                MovieCategories = new List<MovieCategory>
        {
            new MovieCategory { MovieId = 1, CategoryId = actionCategory.Id, Category = actionCategory },
            new MovieCategory { MovieId = 1, CategoryId = sciFiCategory.Id, Category = sciFiCategory },
            new MovieCategory { MovieId = 1, CategoryId = thrillerCategory.Id, Category = thrillerCategory }
        }
            };

            var darkKnightMovie = new Movie
            {
                Id = 2,
                Title = "The Dark Knight",
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                Year = 2008,
                ImdbRating = 9.0m,
                MovieCategories = new List<MovieCategory>
        {
            new MovieCategory { MovieId = 2, CategoryId = actionCategory.Id, Category = actionCategory },
            new MovieCategory { MovieId = 2, CategoryId = crimeCategory.Id, Category = crimeCategory },
            new MovieCategory { MovieId = 2, CategoryId = dramaCategory.Id, Category = dramaCategory }
        }
            };

            var matrixMovie = new Movie
            {
                Id = 3,
                Title = "The Matrix",
                Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                Year = 1999,
                ImdbRating = 8.7m,
                MovieCategories = new List<MovieCategory>
        {
            new MovieCategory { MovieId = 3, CategoryId = actionCategory.Id, Category = actionCategory },
            new MovieCategory { MovieId = 3, CategoryId = sciFiCategory.Id, Category = sciFiCategory }
        }
            };

            var pulpFictionMovie = new Movie
            {
                Id = 4,
                Title = "Pulp Fiction",
                Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                Year = 1994,
                ImdbRating = 8.9m,
                MovieCategories = new List<MovieCategory>
        {
            new MovieCategory { MovieId = 4, CategoryId = crimeCategory.Id, Category = crimeCategory },
            new MovieCategory { MovieId = 4, CategoryId = dramaCategory.Id, Category = dramaCategory },
            new MovieCategory { MovieId = 4, CategoryId = thrillerCategory.Id, Category = thrillerCategory }
        }
            };

            return new List<Movie> { inceptionMovie, darkKnightMovie, matrixMovie, pulpFictionMovie };
        }

    }

}

