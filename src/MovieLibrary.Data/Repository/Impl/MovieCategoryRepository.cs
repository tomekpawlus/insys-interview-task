using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Repository.Impl
{
    public class MovieCategoryRepository : BaseRepository<MovieCategory, int>, IMovieCategoryRepository
    {
        public MovieCategoryRepository(MovieLibraryContext context) : base(context)
        {
        }
    }
}
