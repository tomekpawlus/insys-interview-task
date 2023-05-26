using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Models;

namespace MovieLibrary.Api.Controllers
{

    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class Movie : ControllerBase
    {

        private readonly IMovieService _movieService;

        public Movie(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpPost]
        public ActionResult CreateMovie([FromBody] CreateMovieDTO dto)
        {
            var id = _movieService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery] RestaurantQuery query)
        //{
        //    var restaurantsDtos = _restaurantService.GetAll(query);

        //    return Ok(restaurantsDtos);
        //}

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
