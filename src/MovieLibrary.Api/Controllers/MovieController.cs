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
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Filter([FromQuery] MovieQuery query)
        {
            var moviesList = _movieRepository.GetAll();

            return Ok(moviesList);
        }


    }
}
