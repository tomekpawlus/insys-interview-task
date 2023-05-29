using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using MovieLibrary.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MovieLibrary.Core.Service.Impl
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _movieRepository.GetAll();
        }

        public async Task<Movie> GetById(int id)
        {
            return await _movieRepository.Get(id);
        }
        public async Task Create(Movie movie)
        {
            await _movieRepository.Add(movie);
        }

        public async Task Update(int id, Movie movie)
        {
            await _movieRepository.Update(movie);
        }

        public async Task Delete(int id)
        {
            await _movieRepository.Delete(id);

        }

        public PagedResult<FilteredMovieDto> Filter(MovieQuery movieQuery)
        {

            var baseQuery = _movieRepository.Find()
                .Select(x => new FilteredMovieDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ImdbRating = x.ImdbRating,
                    Year = x.Year,
                    CategoryList = x.MovieCategories
                        .Select(mc => new CategoryDto
                        {
                            Id = mc.Category.Id,
                            Name = mc.Category.Name
                        })
                        .ToList()
                });


            if (!string.IsNullOrEmpty(movieQuery.SearchPhrase))
            {
                baseQuery = baseQuery.Where(m => m.Title.Contains(movieQuery.SearchPhrase));
            }

            if (movieQuery.Categories != null && movieQuery.Categories.Any())
            {
                baseQuery = baseQuery.Where(m => m.CategoryList.Any(c => movieQuery.Categories.Contains(c.Name)));
            }

            if (movieQuery.MinRating.HasValue)
            {
                baseQuery = baseQuery.Where(m => m.ImdbRating >= movieQuery.MinRating.Value);
            }

            if (movieQuery.MaxRating.HasValue)
            {
                baseQuery = baseQuery.Where(m => m.ImdbRating <= movieQuery.MaxRating.Value);
            }

            var filtredQuery = baseQuery.ToList();

            var sortedResult = filtredQuery
                .OrderByDescending(x => x.ImdbRating)
                .ToList();
            var pagedResult = sortedResult
                .Skip(movieQuery.PageSize * (movieQuery.PageNumber - 1))
                .Take(movieQuery.PageSize)
                .ToList();

            var totalCount = sortedResult.Count();

            var result = new PagedResult<FilteredMovieDto>(pagedResult, totalCount, movieQuery.PageSize, movieQuery.PageNumber);

            return result;
        }
    }
}
