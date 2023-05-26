using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Service.Interface
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task Create(Movie movie);
        Task Update(int id, Movie movie);
        Task Delete(int id);
        //Task<PagedResult<Movie>> Filter(MovieQuery movieQuery);
    }
}
