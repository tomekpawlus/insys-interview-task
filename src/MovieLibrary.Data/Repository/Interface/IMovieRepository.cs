using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Repository.Interface
{
    public interface IMovieRepository : IBaseRepository<Movie, int>
    {
    }
}
