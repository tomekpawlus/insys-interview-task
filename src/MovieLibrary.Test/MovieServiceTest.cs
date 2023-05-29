using System.Collections.Generic;
using System.Linq;
using Moq;
using MovieLibrary.Core.Service.Impl;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using MovieLibrary.Data.Repository.Interface;
using MovieLibrary.Test;
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
        var movieQuery = new MovieQuery { SearchPhrase = "Pulp" };
        var movies = TestingData.GetSampleMovies();

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
        var movies = TestingData.GetSampleMovies();

        _movieRepositoryMock.Setup(r => r.Find()).Returns(movies.AsQueryable());

        // Act
        var result = _movieService.Filter(movieQuery);

        // Assert
        Assert.Equal(4, result.Items.Count);
    }
    
    [Fact]
    public void Filter_ReturnsFilteredMovies_WhenMinAndMaxRatingsAreProvided()
    {
        // Arrange
        var movieQuery = new MovieQuery { MinRating = (decimal)7.5, MaxRating = (decimal)8.9 };
        var movies = TestingData.GetSampleMovies();

        _movieRepositoryMock.Setup(r => r.Find()).Returns(movies.AsQueryable());

        // Act
        var result = _movieService.Filter(movieQuery);

        // Assert
        Assert.Equal(3, result.Items.Count);
    }


}

