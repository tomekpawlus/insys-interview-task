using System;
namespace MovieLibrary.Data.Models
{
	public class MovieQuery
	{
            public string SearchPhrase { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string SortBy { get; set; }
            public SortDirectionEnum SortDirection { get; set; }
        
    }
}

