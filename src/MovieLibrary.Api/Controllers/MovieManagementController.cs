using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Api.Controllers
{

    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovieManagementController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieManagementController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpPost]
        public ActionResult CreateMovie([FromBody] Movie movie)
        {
            var id = _movieService.Create(movie);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            var movieList = _movieService.GetAll();
            return Ok(movieList);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] Movie movie, [FromRoute] int id)
        {

            _movieService.Update(id, movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _movieService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get([FromRoute] int id)
        {
            var movie = _movieService.GetById(id);
            return Ok(movie);
        }
    }
}
