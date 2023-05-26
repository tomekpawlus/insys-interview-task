using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using MovieLibrary.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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

        public async Task<List<Movie>>  GetAll()
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

        //public async Task<PagedResult<Movie>> Filter(MovieQuery movieQuery)
        //{

        //    //var baseQuery = _movieRepository
        //    //    .Restaurants
        //    //    .Include(r => r.Address)
        //    //    .Include(r => r.Dishes)
        //    //    .Where(r => movieQuery.SearchPhrase == null || (r.Name.ToLower().Contains(query.SearchPhrase.ToLower())
        //    //                                               || r.Description.ToLower()
        //    //                                                   .Contains(query.SearchPhrase.ToLower())));


        //    if (!string.IsNullOrEmpty(movieQuery.SortBy))
        //    {
        //        var columnsSelectors = new Dictionary<string, Expression<Func<Restaurant, object>>>
        //        {
        //            { nameof(Restaurant.Name), r => r.Name },
        //            { nameof(Restaurant.Description), r => r.Description },
        //            { nameof(Restaurant.Category), r => r.Category },
        //        };

        //        var selectedColumn = columnsSelectors[movieQuery.SortBy];

        //        baseQuery = movieQuery.SortDirection == SortDirection.ASC
        //            ? baseQuery.OrderBy(selectedColumn)
        //        : baseQuery.OrderByDescending(selectedColumn);
        //    }

        //    var restaurants = baseQuery
        //        .Skip(movieQuery.PageSize * (movieQuery.PageNumber - 1))
        //        .Take(movieQuery.PageSize)
        //        .ToList();
        //    var totalItemsCount = baseQuery.Count();
        //    var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

        //    var result = new PagedResult<RestaurantDto>(restaurantsDtos, totalItemsCount, movieQuery.PageSize, movieQuery.PageNumber);

        //    return result;
        //}
    }
}
