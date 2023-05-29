using System;
using System.Collections.Generic;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Models
{
	public class MovieQuery
	{ 
            public string? SearchPhrase { get; set; }
            public List<string>? Categories { get; set; }
            public decimal? MinRating { get; set; }
            public decimal? MaxRating { get; set; }
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 5;      
    }
}

