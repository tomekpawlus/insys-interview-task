using MovieLibrary.Data.Entities;
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
        Task Create(Movie dto);
        Task Update(Movie movie);
        Task Delete(int id);
    }
}
