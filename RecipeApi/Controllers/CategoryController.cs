using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Entities;
using RecipeApi.Services.Interfaces;
using RecipeApi.ControllerBase;

namespace RecipeApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {

        private readonly IBaseService<Category> _baseService;

        public CategoryController(IBaseService<Category> baseService)
        {
            this._baseService = baseService;

        }

        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _baseService.GetAll();
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetById(long id)
        {

            var rec = _baseService.GetById(id);
            if (rec == null)
            {
                return NotFound();
            }
            return Ok(rec);
        }

        // GET: api/Category/5

        // POST: api/Category
        [HttpPost]
        public IActionResult Create([FromBody]Category category)
        {
            Console.WriteLine("\n\ncategory post controleris\n\n");
            var _category = _baseService.Add(category);
            if (_category == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetCategory", new { id = _category.Id }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Category category, [FromRoute] long categoryId)
        {

            var _category = _baseService.Update(id, category);
            if (_category == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var succeded = _baseService.Detele(id);
            if (succeded)
            {
                return new NoContentResult();
            }
            return NotFound();
        }
    }
}
