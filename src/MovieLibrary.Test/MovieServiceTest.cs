using System.Collections.Generic;
using System.Linq;
using Moq;
using MovieLibrary.Core.Service.Impl;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using MovieLibrary.Data.Repository.Interface;
using Xunit;

public class MovieFilterTests
{
    private readonly Mock<IMovieRepository> _movieRepositoryMock;
    private readonly MovieService _movieService;

    public MovieFilterTests()
    {
        _movieRepositoryMock = new Mock<IMovieRepository>();
        _movieService = new MovieService(_movieRepositoryMock.Object);
    }

    [Fact]
    public void Filter_ReturnsFilteredMovies_WhenSearchPhraseIsProvided()
    {
        // Arrange
        var movieQuery = new MovieQuery { SearchPhrase = "Inc" };
        var movies = GetSampleMovies();

        _movieRepositoryMock.Setup(r => r.Find()).Returns(movies.AsQueryable());

        // Act
        var result = _movieService.Filter(movieQuery);

        // Assert
        Assert.Equal(1, result.Items.Count);
    }

    [Fact]
    public void Filter_ReturnsFilteredMovies_WhenCategoriesAreProvided()
    {
        // Arrange
        var movieQuery = new MovieQuery { Categories = new List<string> { "Action", "Crime" } };
        var movies = GetSampleMovies();

        _movieRepositoryMock.Setup(r => r.Find()).Returns(movies.AsQueryable());

        // Act
        var result = _movieService.Filter(movieQuery);

        // Assert
        Assert.Equal(1, result.Items.Count);
    }
    
    [Fact]
    public void Filter_ReturnsFilteredMovies_WhenMinAndMaxRatingsAreProvided()
    {
        // Arrange
        var movieQuery = new MovieQuery { MinRating = (decimal)7.5, MaxRating = (decimal)8.9 };
        var movies = GetSampleMovies();

        _movieRepositoryMock.Setup(r => r.Find()).Returns(movies.AsQueryable());

        // Act
        var result = _movieService.Filter(movieQuery);

        // Assert
        Assert.Equal(1, result.Items.Count);
    }


    private List<Movie> GetSampleMovies()
    {
        var movies = new List<Movie>
    {
        new Movie
        {
            Id = 1,
            Title = "Inception",
            Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
            Year = 2010,
            ImdbRating = 8.8m,
            MovieCategories = new List<MovieCategory>
            {
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 1
                },
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 4
                },
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 6
                }
            }
        },
        new Movie
        {
            Id = 2,
            Title = "The Dark Knight",
            Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
            Year = 2008,
            ImdbRating = 9.0m,
            MovieCategories = new List<MovieCategory>
            {
                new MovieCategory
                {
                    MovieId = 2,
                    CategoryId = 1
                },
                new MovieCategory
                {
                    MovieId = 2,
                    CategoryId = 3
                },
                new MovieCategory
                {
                    MovieId = 2,
                    CategoryId = 5
                }
            }
        }
    };

        return movies;
    }

    private List<Category> GetSampleCategories()
    {
        var categories = new List<Category>
    {
        new Category
        {
            Id = 1,
            Name = "Action",
            MovieCategories = new List<MovieCategory>
            {
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 1
                },
                new MovieCategory
                {
                    MovieId = 2,
                    CategoryId = 1
                }
            }
        },
        new Category
        {
            Id = 3,
            Name = "Crime",
            MovieCategories = new List<MovieCategory>
            {
                new MovieCategory
                {
                    MovieId = 2,
                    CategoryId = 3
                }
            }
        },
        new Category
        {
            Id = 4,
            Name = "Sci-Fi",
            MovieCategories = new List<MovieCategory>
            {
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 4
                }
            }
        },
        new Category
        {
            Id = 5,
            Name = "Drama",
            MovieCategories = new List<MovieCategory>
            {
                new MovieCategory
                {
                    MovieId = 2,
                    CategoryId = 5
                }
            }
        },
        new Category
        {
            Id = 6,
            Name = "Thriller",
            MovieCategories = new List<MovieCategory>
            {
                new MovieCategory
                {
                    MovieId = 1,
                    CategoryId = 6
                }
            }
        }
    };

        return categories;
    }

}

