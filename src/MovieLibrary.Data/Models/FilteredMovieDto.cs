using System;
using System.Collections.Generic;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Models
{
	public class FilteredMovieDto
	{
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }
        
        public decimal ImdbRating { get; set; }

        public List<CategoryDto> CategoryList { get; set; }
	}
}

