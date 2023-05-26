using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Repository.Impl
{
    public class MovieRepository : BaseRepository<Movie, int>, IMovieRepository
    {
        public MovieRepository(MovieLibraryContext context) : base(context)
        {

        }
    }
}
