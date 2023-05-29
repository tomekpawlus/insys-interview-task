using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using MovieLibrary.Data.Repository.Interface;
using System.Collections.Generic;

namespace MovieLibrary.Api.Controllers
{

    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        public ActionResult<PagedResult<Movie>> Filter([FromQuery] MovieQuery query)
        {
            var moviesList = _movieService.Filter(query);

            return Ok(moviesList);
        }


    }
}
