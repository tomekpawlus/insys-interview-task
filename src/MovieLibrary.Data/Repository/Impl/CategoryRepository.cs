using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Repository.Impl
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(MovieLibraryContext context) : base(context)
        {
        }
    }
}
