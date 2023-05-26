using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Service.Interface;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Api.Controllers
{

    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryManagementController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryManagementController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        public ActionResult CreateMovie([FromBody] Category category)
        {
            var id = _categoryService.Create(category);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            var categoryList = _categoryService.GetAll();
            return Ok(categoryList);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] Category category, [FromRoute] int id)
        {

            _categoryService.Update(id, category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get([FromRoute] int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }


    }
}
