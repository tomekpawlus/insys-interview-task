using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Data.Entities;
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

        //[HttpPut("{id}")]
        //public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        //{

        //    _restaurantService.Update(id, dto);

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete([FromRoute] int id)
        //{
        //    _restaurantService.Delete(id);

        //    return NoContent();
        //}



        //[HttpGet("{id}")]
        //[AllowAnonymous]
        //public ActionResult<RestaurantDto> Get([FromRoute] int id)
        //{
        //    var restaurant = _restaurantService.GetById(id);

        //    return Ok(restaurant);
        //}

    }
}
