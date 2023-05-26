using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task Update(Movie movie)
        {
            await _movieRepository.Update(movie);
        }

        public async Task Delete(int id)
        {
            await _movieRepository.Delete(id);

        }
    }
}
